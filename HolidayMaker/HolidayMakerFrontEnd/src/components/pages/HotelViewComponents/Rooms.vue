<template>
  <div class="container">
    <div class="row">
      <!-- left column -->
      <div class="col-md-6">
        <Room v-for="room in hotelInfo.rooms" :room="room" :key="room.id" />
      </div>

      <!-- right column -->
      <div class="col-md-6 rounded shadow-sm" id="rightCard">
        <Options @checked="setExtraBedFee" />

        <!-- Pension type -->
        <div class="row">
          <SelectButton @click="getServicetype" v-model="value" :options="serviceTypes" />
        </div>

        <div class="row pt-5">
          <div class="col-md-6">
            <b>Total price: {{ totalprice }} SEK</b>
          </div>
          <div class="col-md-6">
            <div v-if="CanBook">
            <router-link to="/checkout" class="btn btn-primary" @click="Book"
              ><span class="far fa-bookmark"></span> Book</router-link
            >
            </div>
            <div v-else>
              <b>Select service type and rooms to proceed to booking</b>
            </div>    
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Room from "./RoomsViewComponents/Room.vue";
import Options from "./RoomsViewComponents/Option.vue";
import SelectButton from 'primevue/selectbutton';
export default {
  components: {
    Room,
    Options,
    SelectButton
  },
  data(){
    return{
      value: null,
      serviceTypes: ['Self service', 'Half board', 'Full board', 'All inclusive'],
    }
  },
  computed: {
    hotelInfo() {
      return this.$store.state.hotel;
    },
    totalprice() {
      if(this.$store.state.searchString.dates[1] != null){
        this.$store.dispatch('getTotalPrice');
        return this.$store.state.bookingDetails.totalprice;
      }
    },
    CanBook(){
      var single = this.$store.state.bookingDetails.noOfSingleRooms > 0;
      var double = this.$store.state.bookingDetails.noOfDoubleRooms > 0;
      var family = this.$store.state.bookingDetails.noOfFamilyRooms > 0;
      if(this.value != null && (single || double || family)) {
        return true;
      }
      return false;
    },
  },
  methods: {
    setExtraBedFee() {
      this.$store.dispatch('setExtraBedFee', this.hotelInfo.extraBedFee);
    },
    getServicetype(value) {
      this.serviceType = value.path[0].innerText;
      this.$store.dispatch('setServiceType', this.serviceType);

      let id = this.$route.params.id;
      this.$store.dispatch('setServiceFee', { id: id, type: this.serviceType });
    },
    Book() {
      this.$store.dispatch('setHotelName', this.hotelInfo.name)
      this.$store.dispatch('setHotelId', this.hotelInfo.id)
      window.scrollTo(0,0)
    },
  },
  created(){
    if(this.$store.state.bookingDetails.serviceType !== ''){
      this.value = this.$store.state.bookingDetails.serviceType;
    }
  }
};
</script>


<style scoped>

  .p-buttonset .p-button.p-highlight {
    background:#53c16e !important;
    border-color:#1bc541 !important;
  }

  .p-buttonset .p-button.p-highlight:hover{
    background:#53c16e !important;
    border-color:#1bc541 !important;
  }

  .btn.btn-primary{
    background-color:#53c16e;
    border-color:#1bc541;
  }

  .container {
    padding-top: 20px;
  }

  #rightCard {
    margin-bottom: 15px;
  }

</style>