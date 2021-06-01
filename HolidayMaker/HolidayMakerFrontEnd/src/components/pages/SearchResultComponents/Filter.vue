<template>

  
  
  <div>
    <h1>Search results: {{hotelsCount}} found</h1>
    <Result :filteredHotels="filteredHotels"/>
    <div>
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
      <p>Distance to beach (km)</p>
      <Slider
        v-model="beachDistance.value"
        v-bind="beachDistance"
        :max="5000"
      ></Slider>
    </div>
    <hr />
    <div>
      <p>Distance to city (km)</p>
      <Slider v-model="centrumDistance.value" v-bind="centrumDistance" :max="5000"></Slider>
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
                  type="checkbox"
                  value=""
                  id="flexCheckDefault"
                />
                <label class="form-check-label" for="flexCheckDefault">
                  Pool
                </label>
              </div>
              <div class="form-check">
                <input
                  class="form-check-input"
                  type="checkbox"
                  value=""
                  id="flexCheckDefault"
                />
                <label class="form-check-label" for="flexCheckDefault">
                  Night Entertainment
                </label>
              </div>
              <div class="form-check">
                <input
                  class="form-check-input"
                  type="checkbox"
                  value=""
                  id="flexCheckDefault"
                />
                <label class="form-check-label" for="flexCheckDefault">
                  Child club
                </label>
              </div>
              <div class="form-check">
                <input
                  class="form-check-input"
                  type="checkbox"
                  value=""
                  id="flexCheckDefault"
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
 
   
  
</template>

<script>
// code: https://www.vuescript.com/custom-range-slider/
import Slider from "/node_modules/@vueform/slider";
import Images from '../HotelViewComponents/RoomPhotoSlider.vue'
import Info from '../HotelViewComponents/Info.vue'
import Result from './Result.vue'


export default {
  components: {
    Slider,
    Images,
    Info,
    Result
  },

  data() {
    return {
      pricerange: {
        value: [0, 40000],
      },
      beachDistance: {
        value: [500],
      },
      centrumDistance: {
        value: [800],
      },
    };
  },
  computed:{
        hotels(){
            return this.$store.state.seachResults;
        },
        hotelsCount(){
            return this.filteredHotels.length;
        },
       
    filteredHotels() {
      let result = this.hotels.filter(
        (hotel) => hotel.beachDistance <= this.beachDistance.value
      );
      result = result.filter(
        (hotel) => hotel.centrumDistance <= this.centrumDistance.value
      );
      
      return result
    }
    }
 
};
</script>

<style src="@vueform/slider/themes/default.css"></style>

<style scoped></style>
