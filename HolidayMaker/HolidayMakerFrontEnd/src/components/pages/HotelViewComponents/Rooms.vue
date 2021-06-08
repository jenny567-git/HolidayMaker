<template>
  <div class="container">
    <div class="row">
      <!-- left column -->
      <div class="col-md-6">
        <Room v-for="room in hotelInfo.rooms" :room="room" :key="room.id" />
      </div>

      <!-- right column -->
      <div class="col-md-6 rounded shadow-sm">
        <Options @checked="setExtraBedFee" />

        <!-- Pension type -->
        <div class="row">
          <!-- <ServiceType @serviceType="getServicetype" /> -->
          <SelectButton @click="getServicetype" v-model="value" :options="serviceTypes" />
        </div>

        <div class="row pt-5">
          <div class="col-md-6">
            <p>Total price: {{ totalprice }} SEK</p>
          </div>
          <div class="col-md-6">
            <div v-if="value != null">
            <router-link to="/checkout" class="btn btn-primary" @click="Book"
              >Book</router-link
            >
            </div>
            <div v-else>
              <p>Select service type to proceed to booking</p>
            </div>    
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Images from "./RoomPhotoSlider.vue";
import Room from "./RoomsViewComponents/Room.vue";
import ServiceType from "./RoomsViewComponents/ServiceType.vue";
import Options from "./RoomsViewComponents/Option.vue";
import SelectButton from 'primevue/selectbutton';
export default {
  components: {
    Images,
    Room,
    ServiceType,
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
  },
  methods: {
    setExtraBedFee() {
      this.$store.dispatch('setExtraBedFee', this.hotelInfo.extraBedFee);
    },
    getServicetype(value) {
      this.serviceType = value.path[0].innerText;
      this.$store.dispatch('setServiceType', this.serviceType);

      console.log("set fee");
      let id = this.$route.params.id;
      this.$store.dispatch('setServiceFee', { id: id, type: this.serviceType });
    },
    Book() {
      this.$store.dispatch('setHotelName', this.hotelInfo.name)
      this.$store.dispatch('setHotelId', this.hotelInfo.id)
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

  /* .btn.btn-primary{
    background-color:#43744f;
    border-color:black;
  } */

  .container {
    padding-top: 20px;
  }


</style>