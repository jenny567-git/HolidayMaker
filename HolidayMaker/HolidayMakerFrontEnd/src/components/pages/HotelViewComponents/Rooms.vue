<template>
  <div class="container">
    <div class="row">
      <!-- left column -->
      <div class="col-md-6">
        <Room v-for="room in hotelInfo.rooms" :room="room" :key="room.id" />
      </div>

      <!-- right column -->
      <div class="col-md-6">
        <Options @checked="setExtraBedFee"/>
        <!-- Amount
          <input type="number" min="1" value="1" /> -->

        <!-- Pension type -->
        <div class="row">
          <ServiceType v-bind="serviceType" @serviceType="getServicetype" />
        </div>

        <div class="row pt-5">
          <div class="col-md-6">
            <p>Total price: {{totalprice}} SEK </p>
          </div>
          <div class="col-md-6">
            <router-link to="/checkout" class="btn btn-primary" @click="Book"
              >Book</router-link
            >
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

export default {
  components: {
    Images,
    Room,
    ServiceType,
    Options,
  },
  mounted(){
    this.getTotalPrice();
  },
  data() {
    return {
      serviceType: null,
    };
  },
  computed: {
    hotelInfo() {
      return this.$store.state.hotel;
    },
    totalprice() {
        this.$store.dispatch('getTotalPrice');
        return this.$store.state.bookingDetails.totalprice;
    },
    
  },
  methods: {
    getTotalPrice(){
      this.$store.dispatch('getTotalPrice');
    },
    setExtraBedFee(){
      this.$store.dispatch('setExtraBedFee', this.hotelInfo.extraBedFee)
    },
    getServicetype(value) {
      this.$store.dispatch('setServiceType', value );
    },
    Book() {
      // this.$store.dispatch('book', this.);
    },
  },
};
</script>
