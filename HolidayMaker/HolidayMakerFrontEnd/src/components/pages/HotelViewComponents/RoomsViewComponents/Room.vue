<template>
  <div class="p-4 rounded shadow-sm">
    <div class="row">
      <div class="col">
        <img :src="room.img" alt="" width="250" height="150" />
      </div>
      <div class="col">
        <h3>{{ room.type }}</h3>

        <p>Rooms:</p>
        <div
          v-if="
            $store.state.searchString.dates.length &&
            $store.state.seachResults.length
          "
        >
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
        </div>
        <p v-else>Fill in dates to see available rooms</p>
      </div>
      <div class="row">
        <div class="col-md-6">
          <p>
            Max Capacity: {{ room.maxCapacity }}
            <i class="fas fa-user-alt"></i>
          </p>
          <p>
            Price/unit: <span style="color: red">{{ room.price }} SEK</span>
          </p>
        </div>
      </div>
      <div class="row"></div>
    </div>
  </div>
</template>

<script>
import InputNumber from "primevue/inputnumber";

export default {
  components: {
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
    if (this.$store.state.seachResults.length) {
      this.array = this.$store.state.seachResults;
      this.arrayIndex = this.array.findIndex(
        (i) => i.hotel.id == this.$route.params.id
      );
      if (this.array[this.arrayIndex].roomList) {
        this.singleRooms = this.array[this.arrayIndex].roomList.singleRooms;
        this.doubleRooms = this.array[this.arrayIndex].roomList.doubleRooms;
        this.familyRooms = this.array[this.arrayIndex].roomList.familyRooms;
      }
    }
  },
  computed: {
    inputSingleRooms: {
      get() {
        return this.$store.state.bookingDetails.noOfSingleRooms;
      },
      set(noOfUnit) {
        if (this.room.type == "Single") {
          let unitPrice = this.room.price;
          let roomId = this.room.id;
          this.$store.dispatch("setSingleRooms", {
            noOfUnit,
            unitPrice,
            roomId,
          });
        }
      },
    },
    inputDoubleRooms: {
      get() {
        return this.$store.state.bookingDetails.noOfDoubleRooms;
      },
      set(noOfUnit) {
        if (this.room.type == "Double") {
          let unitPrice = this.room.price;
          let roomId = this.room.id;
          this.$store.dispatch("setDoubleRooms", {
            noOfUnit,
            unitPrice,
            roomId,
          });
        }
      },
    },
    inputFamilyRooms: {
      get() {
        return this.$store.state.bookingDetails.noOfFamilyRooms;
      },
      set(noOfUnit) {
        if (this.room.type == "Family") {
          let unitPrice = this.room.price;
          let roomId = this.room.id;
          this.$store.dispatch("setFamilyRooms", {
            noOfUnit,
            unitPrice,
            roomId,
          });
        }
      },
    },
  },
};
</script>

<style >
input {
  width: 70px;
}
</style>

<style scoped>
p {
  padding-top: 5px;
}

.p-4 {
  margin-bottom: 15px;
  background-color: rgb(241, 241, 241);
}
</style>