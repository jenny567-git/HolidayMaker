<template>
  <div class="container">
    <div class="row">
      <!-- left column -->
      <div class="col-md-6">
        <Room v-for="room in hotelInfo.rooms"  :room="room" :key="room.id"/>
      </div>

      <!-- right column -->
      <div class="col-md-6">
        <Options/>
          <!-- Amount
          <input type="number" min="1" value="1" /> -->
        

        <!-- Pension type -->
        <div class="row">
          <ServiceType/>
        </div>

        <div class="row pt-5">
          <div class="col-md-6">
            <p>Total price: 1223 SEK</p>
          </div>
          <div class="col-md-6">
            <router-link to="/checkout" class="btn btn-primary"
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
    Options
  },
  computed: {
    hotelInfo() {
      return this.$store.state.hotel;
    },
  },
};
</script>
