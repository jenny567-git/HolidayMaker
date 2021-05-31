<template>
  <div id="test3">
    <div class="row">
      <div class="col">
        <Images :id="room.id"/>
      </div>
      <div class="col">
        <h3>{{ room.type }}</h3>
      </div>
      <div class="row">
        <div class="col-md-6">
          <p>
            Max Capacity: {{(room.maxCapacity)}}
            <i class="fas fa-user-alt"></i>
          </p>
        </div>
        <div class="col-md-6">
          <p> Rooms:</p>
            <div v-if="$store.state.searchString.dates.length">
                <input type="number" min="0" value="0" max=""/> 
            </div>
          <p v-else>Fill in dates to see available rooms</p>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <p>Price/unit:</p>
        </div>
        <div class="col-md-6">
          <p style="color: red">{{room.price}} SEK</p>
        </div>
      </div>
    </div>
    <hr />
  </div>
</template>

<script>
import Images from "../RoomPhotoSlider.vue";

export default {
  components: {
    Images,
  },
  data(){
    return{
    singleRooms:null,
    doubleRooms:null,
    familyRooms:null,
    }
  },
  props: {
    room: {},
  },
  mounted(){
    console.log('in room mounted');
    if(this.$store.state.seachResults){
      let array = this.$store.state.seachResults;
      let arrayIndex = array.findIndex(i => i.hotel.id == this.$route.params.id);
      this.singleRooms = array[arrayIndex].roomList.singleRooms;
      this.doubleRooms = array[arrayIndex].roomList.doubleRooms;
      this.familyRooms = array[arrayIndex].roomList.familyRooms;
      console.log('single rooms' + this.singleRooms);
      console.log('double rooms' + this.doubleRooms);
      console.log('family rooms' + this.familyRooms);

    }
  }
};
</script>

<style>
</style>