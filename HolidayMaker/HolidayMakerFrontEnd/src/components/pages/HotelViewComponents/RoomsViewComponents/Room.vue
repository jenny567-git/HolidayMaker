<template>
  <div id="test3">
    <div class="row">
      <div class="col">
        <Images :id="room.id" />
      </div>
      <div class="col">
        <h3>{{ room.type }}</h3>
      </div>
      <div class="row">
        <div class="col-md-6">
          <p>
            Max Capacity: {{ room.maxCapacity }}
            <i class="fas fa-user-alt"></i>
          </p>
        </div>
        <div class="col-md-6">
          <p>Rooms:</p>
          <div v-if="$store.state.searchString.dates.length">
            <InputNumber
              v-if="room.type == 'Single'"
              v-model="inputSingleRooms"
              showButtons
              :min="0"
              :max="singleRooms"
              :value="inputSingleRooms"
            />
            <InputNumber
              v-if="room.type == 'Double'"
              v-model="inputDoubleRooms"
              showButtons
              :min="0"
              :max="doubleRooms"
              :value="inputDoubleRooms"
            />
            <InputNumber
              v-if="room.type == 'Family'"
              v-model="inputFamilyRooms"
              showButtons
              :min="0"
              :max="familyRooms"
              :value="inputFamilyRooms"
            />
            <!-- <input v-if="room.type == 'Single'" type="number" min="0" value="0" :max="singleRooms"/> 
                <input v-if="room.type == 'Double'" type="number" min="0" value="0" :max="doubleRooms"/> 
                <input v-if="room.type == 'Family'" type="number" min="0" value="0" :max="familyRooms"/>  -->
          </div>
          <p v-else>Fill in dates to see available rooms</p>
        </div>
      </div>
      <div class="row">
        <div class="col-md-6">
          <p>Price/unit:</p>
        </div>
        <div class="col-md-6">
          <p style="color: red">{{ room.price }} SEK</p>
        </div>
      </div>
    </div>
    <hr />
  </div>
</template>

<script>
import Images from "../RoomPhotoSlider.vue";
import InputNumber from "primevue/inputnumber";

export default {
  components: {
    Images,
    InputNumber,
  },
  data() {
    return {
      array: [],
      arrayIndex: null,
      singleRooms: null,
      doubleRooms: null,
      familyRooms: null,
    };
  },
  props: {
    room: {},
  },
  mounted() {
    // console.log("in room mounted");
    if (this.$store.state.seachResults.length) {
      this.array = this.$store.state.seachResults;
      this.arrayIndex = this.array.findIndex(
        (i) => i.hotel.id == this.$route.params.id
      );
      this.singleRooms = this.array[this.arrayIndex].roomList.singleRooms;
      this.doubleRooms = this.array[this.arrayIndex].roomList.doubleRooms;
      this.familyRooms = this.array[this.arrayIndex].roomList.familyRooms;
      // console.log("single rooms" + this.singleRooms);
      // console.log("double rooms" + this.doubleRooms);
      // console.log("family rooms" + this.familyRooms);
    }
  },
  computed: {
    inputSingleRooms: {
      get() {
        return this.$store.state.bookingDetails.noOfSingleRooms;
      },
      set(noOfUnit) {
        console.log('single input: ' + noOfUnit);
        if(this.room.type == 'Single'){
          let unitPrice = this.room.price;
          this.$store.dispatch("setSingleRooms", {noOfUnit, unitPrice});
        }
      },
    },
    inputDoubleRooms: {
      get() {
        return this.$store.state.bookingDetails.noOfDoubleRooms;
      },
      set(noOfUnit) {
        console.log('double input: ' + noOfUnit);
        if(this.room.type == 'Double'){
          let unitPrice = this.room.price
          this.$store.dispatch("setDoubleRooms", {noOfUnit, unitPrice});
        }
        
      },
    },
    inputFamilyRooms: {
      get() {
        return this.$store.state.bookingDetails.noOfFamilyRooms;
      },
      set(noOfUnit) {
        console.log('family input: ' + noOfUnit);
        if(this.room.type == 'Family'){
          let unitPrice = this.room.price
          this.$store.dispatch("setFamilyRooms", {noOfUnit, unitPrice});
        }
      },
    },
  },
};
</script>

<style>
</style>