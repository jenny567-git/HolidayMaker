<template>
  <div class="row">
    <div class="col-md-4">
      <div id="sliders">
        <div>
          <p>Price range (SEK)</p>
          <Slider
            v-model="pricerange.value"
            v-bind="pricerange"
            :max="2000"
          ></Slider>
        </div>
        <hr />
        <div>
          <p>Distance to beach</p>
          <Slider
            v-model="beachDistance.value"
            v-bind="beachDistance"
            :max="7"
          ></Slider>
        </div>
        <hr />
        <div>
          <p>Distance to city</p>
          <Slider
            v-model="centrumDistance.value"
            v-bind="centrumDistance"
            :max="5"
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
                      Kids club
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
    </div>
    <div class="col-md-8">
      <Result
        v-for="result in filteredHotels"
        :hotel="result.hotel"
        :key="result.hotel.id"
      />
    </div>
  </div>
</template>
<script>
// code: https://www.vuescript.com/custom-range-slider/
import Slider from "/node_modules/@vueform/slider";
import Images from "../HotelViewComponents/RoomPhotoSlider.vue";
import Info from "../HotelViewComponents/Info.vue";
import Result from "./Result.vue";

export default {
  components: {
    Slider,
    Images,
    Info,
    Result,
  },

  data() {
    return {
      pricerange: {
        value: [0, 2000],
      },
      beachDistance: {
        value: 7,
        step: -1,
        format:{
          decimals: 1,
          suffix: ' km'
        }
      },
      centrumDistance: {
        value: 10,
        step:-1,
        format:{
          decimals:1,
          suffix: ' km'
        }
      },
      pool: false,
      nightEntertainment: false,
      childClub: false,
      restaurant: false,
    };
  },
  computed: {
    searchResults() {
      return this.$store.state.seachResults;
    },
    hotelsCount() {
      return this.filteredHotels.length;
    },

    filteredHotels() {
      
      //filter price
      let result = this.searchResults.filter(
        (res) => this.pricerange.value[0] <= res.hotel.rooms[0].price && res.hotel.rooms[0].price <= this.pricerange.value[1]
        );
        
      result = result.filter(
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
    },
  },
};
</script>

<style src="@vueform/slider/themes/default.css">
</style>

<style scoped>
  #sliders{
    color:rgb(255, 255, 255);
    
  }

.accordion {
  color: black;
}
.slider-connect {
  background: #5a3ff5;
  cursor: pointer;
}
</style>
