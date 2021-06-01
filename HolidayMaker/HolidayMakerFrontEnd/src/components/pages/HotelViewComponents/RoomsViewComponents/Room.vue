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
              value="0"
            />
            <InputNumber
              v-if="room.type == 'Double'"
              v-model="inputDoubleRooms"
              showButtons
              :min="0"
              :max="doubleRooms"
              value="0"
            />
            <InputNumber
              v-if="room.type == 'Family'"
              v-model="inputFamilyRooms"
              showButtons
              :min="0"
              :max="familyRooms"
              value="0"
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
    console.log("in room mounted");
    //move to parent component?
    if (this.$store.state.seachResults.length) {
      this.array = this.$store.state.seachResults;
      this.arrayIndex = this.array.findIndex(
        (i) => i.hotel.id == this.$route.params.id
      );
      this.singleRooms = this.array[this.arrayIndex].roomList.singleRooms;
      this.doubleRooms = this.array[this.arrayIndex].roomList.doubleRooms;
      this.familyRooms = this.array[this.arrayIndex].roomList.familyRooms;
      console.log("single rooms" + this.singleRooms);
      console.log("double rooms" + this.doubleRooms);
      console.log("family rooms" + this.familyRooms);
    }
  },
  computed: {
    inputSingleRooms: {
      set(value) {
        console.log('single input: ' + value);
        this.$store.dispatch("setSingleRooms", value);
      },
    },
    inputDoubleRooms: {
      set(value) {
        console.log('double input: ' + value);
        this.$store.dispatch("setDoubleRooms", value);
      },
    },
    inputFamilyRooms: {
      set(value) {
        console.log('family input: ' + value);
        this.$store.dispatch("setFamilyRooms", value);
      },
    },
  },
};
</script>

<style>
</style>