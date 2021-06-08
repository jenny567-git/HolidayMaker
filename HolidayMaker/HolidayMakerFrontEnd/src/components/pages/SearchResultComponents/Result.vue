<template>
  <div class="p-4 rounded shadow-sm">
    <div id="testOmega">
      <div class="row">
        <div class="col-md-4">
          <PhotoSlider :photos="photos" :key="hotel.id"/>
        </div>
        <div class="col-md-8">
          <div class="row">
            <div class="col-md-6 text-start">
              <b>{{ hotel.name }}</b>
              <p>{{ hotel.city.cityName }}, {{ hotel.country.countryName }}</p>
              <p>
                Ratings:
                <span class="badge rounded-pill bg-secondary">{{
                  hotel.averageRating
                }}</span>
              </p>
              <p>
                Beach distance:
                <span class="badge rounded-pill bg-secondary"
                  >{{ hotel.beachDistance }} km
                </span>
              </p>
              <p>
                Centrum distance:
                <span class="badge rounded-pill bg-secondary"
                  >{{ hotel.centrumDistance }} km
                </span>
              </p>
            </div>
            <div class="col-md-6 text-start">
              <h5>
                <small>from</small> <b>{{ lowestPrice }} kr/unit</b>
              </h5>
              <br />
              <p v-if="hotel.pool"><i class="fas fa-check"></i> Pool</p>
              <p v-if="hotel.nightEntertainment">
                <i class="fas fa-check"></i> Night Entertainment
              </p>
              <p v-if="hotel.childClub">
                <i class="fas fa-check"></i> Kids club
              </p>
              <p v-if="hotel.restaurant">
                <i class="fas fa-check"></i> Restaurant
              </p>
            </div>
          </div>
          <router-link :to="'/hotels/' + hotel.id" class="nav-link">
            <button
              class="btn btn-primary"
              for="btn-check-outlined"
              @click="hotelDetailsClick"
            >
              See details</button
            ><br />
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import Images from "../HotelViewComponents/RoomPhotoSlider.vue";
import Info from "../HotelViewComponents/Info.vue";
import PhotoSlider from "../HotelViewComponents/RoomsViewComponents/PhotoSlider.vue";

export default {
  components: {
    Images,
    Info,
    PhotoSlider,
  },
  computed: {
    lowestPrice() {
      var rooms = this.hotel.rooms;
      rooms.sort((a, b) => {
        return a.price - b.price;
      });
      var min = rooms[0];
      return min.price;
    },
    photos() {
      var photos = [];
      photos.push({id: this.hotel.id, roomPhoto: this.hotel.img});
      this.hotel.rooms.forEach(room => {
          photos.push({id: this.hotel.id, roomPhoto: room.img})
      });
      return photos;
    },
  },
  props: {
    hotel: {},
  },
  methods: {
    hotelDetailsClick(event) {
      console.log("Set hotel in result", this.hotel.id);
      this.$store.dispatch("setHotel", this.hotel);
    },
  },
};
</script>

<style scoped>
#testOmega {
  opacity: 100% !important;
}

.btn.btn-primary{
    background-color:#53c16e;
    border-color:#1bc541;
  }

a.nav-link {
  margin-left: 35mm;
}

.p-4 {
  margin-top: 15px;
  background-color: rgb(241, 241, 241);
}
</style>