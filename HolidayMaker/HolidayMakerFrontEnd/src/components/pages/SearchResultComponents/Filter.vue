<template>
  <div class="row">
    <div class="col-md-4">
      <Card>
        <template #content>
      <div id="sliders">
        <div>
          <p>Price range (SEK)</p>
          <Slider
            v-model="pricerange.value"
            v-bind="pricerange"
            :max="50000"
          ></Slider>
        </div>
        <hr />
        <div>
          <p>Distance to beach (m)</p>
          <Slider
            v-model="beachDistance.value"
            v-bind="beachDistance"
            :max="8000"
          ></Slider>
        </div>
        <hr />
        <div>
          <p>Distance to city (km)</p>
          <Slider
            v-model="centrumDistance.value"
            v-bind="centrumDistance"
            :max="5000"
          ></Slider>
        </div>
        <hr />
        <div>
          <div class="accordion accordion-flush" id="accordionFlushExample">
            <div class="accordion-item">
              <h2 class="accordion-header" id="flush-headingOne">
                <button
                  class="accordion-button collapsed"
                  type="button"
                  data-bs-toggle="collapse"
                  data-bs-target="#flush-collapseOne"
                  aria-expanded="false"
                  aria-controls="flush-collapseOne"
                >
                  More filter
                </button>
              </h2>
              <div
                id="flush-collapseOne"
                class="accordion-collapse collapse"
                aria-labelledby="flush-headingOne"
                data-bs-parent="#accordionFlushExample"
              >
                <div class="accordion-body text-start">
                  <div class="form-check">
                    <input
                      class="form-check-input"
                      v-model="pool"
                      type="checkbox"
                      value=""
                      id="flexCheckDefault"
                      @click="pool = !pool"
                    />
                    <label class="form-check-label" for="flexCheckDefault">
                      Pool
                    </label>
                  </div>
                  <div class="form-check">
                    <input
                      class="form-check-input"
                      v-model="nightEntertainment"
                      type="checkbox"
                      value=""
                      id="flexCheckDefault"
                      @click="nightEntertainment = !nightEntertainment"
                    />
                    <label class="form-check-label" for="flexCheckDefault">
                      Night Entertainment
                    </label>
                  </div>
                  <div class="form-check">
                    <input
                      class="form-check-input"
                      v-model="childClub"
                      type="checkbox"
                      value=""
                      id="flexCheckDefault"
                      @click="childClub = !childClub"
                    />
                    <label class="form-check-label" for="flexCheckDefault">
                      Child club
                    </label>
                  </div>
                  <div class="form-check">
                    <input
                      class="form-check-input"
                      v-model="restaurant"
                      type="checkbox"
                      value=""
                      id="flexCheckDefault"
                      @click="restaurant = !restaurant"
                    />
                    <label class="form-check-label" for="flexCheckDefault">
                      Restaurant
                    </label>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      </template>
     </Card>
    </div>

    <div v-if="filteredHotels.length" class="col-md-8">

      <Card>
        <template #content>
          <Result
            v-for="result in filteredHotels"
            :hotel="result.hotel"
            :key="result.hotel.id"
          />
        </template>
      </Card>
      
    </div>
    <div v-else class="col-md-8 float-container">
      <Card>
        <template #content>
          <Skel v-for="n in nrOfSkeletons" :key="n"></Skel>
        </template>
      </Card>
    </div>
  </div>
</template>
<script>
// code: https://www.vuescript.com/custom-range-slider/
import Slider from "/node_modules/@vueform/slider";
import Images from "../HotelViewComponents/RoomPhotoSlider.vue";
import Info from "../HotelViewComponents/Info.vue";
import Result from "./Result.vue";
import Skel from "./Skel.vue";
import Card from 'primevue/card';
export default {
  components: {
    Slider,
    Images,
    Info,
    Result,
    Skel,
    Card,
  },
  data() {
    return {
      pricerange: {
        value: [0, 40000],
      },
      beachDistance: {
        value: 8000,
      },
      centrumDistance: {
        value: 800,
      },
      pool: false,
      nightEntertainment: false,
      childClub: false,
      restaurant: false,
    };
  },
  computed: {
    nrOfSkeletons(){
      return 3
    },
    searchResults() {
      return this.$store.state.seachResults;
    },
    hotelsCount() {
      return this.filteredHotels.length;
    },
    filteredHotels() {
      if(this.searchResults.length){
        let result = this.searchResults.filter(
          (res) => res.hotel.beachDistance <= this.beachDistance.value
        );

        result = result.filter(
          (res) => res.hotel.centrumDistance <= this.centrumDistance.value
        );

        if (this.pool) {
          result = result.filter((res) => res.hotel.pool == this.pool);
        }

        if (this.nightEntertainment) {
          result = result.filter(
            (res) => res.hotel.nightEntertainment == this.nightEntertainment
          );
        }

        if (this.childClub) {
          result = result.filter((res) => res.hotel.childClub == this.childClub);
        }

        if (this.restaurant) {
          result = result.filter(
            (res) => res.hotel.restaurant == this.restaurant
          );
        }
        this.$emit("updateNrOfHotels", result.length);
        return result;
      }
      return 0;
    },
  },
};
</script>

<style src="@vueform/slider/themes/default.css">
</style>

<style scoped>

.myContainer {
  width: 300%;
  height: auto;
  margin: 10px;
  padding: 10px;
  display: grid;
}
.hotelResults {
  width: 30%;
  height: fit-content;
  margin: auto;
  margin-right: 5px;
}
.myFilter {
  width: 101%;
  margin-left: 5px;
  position: absolute;
}
#sliders {
  color: rgb(0, 0, 0);
}

.accordion {
  color: black;
}
.slider-connect {
  background: #5a3ff5;
  cursor: pointer;
}
</style>
