<template>
<div class="row">
  <!--<div class="myFilter">-->
  <div id="sliders">
    <h1>Search results: {{hotelsCount}} found</h1>
    <div class="col-md-4">
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
    <div class="col-md-8">
        <div class="hotelResults">
            <Result v-for="result in filteredHotels" :hotel="result.hotel" :key="result.hotel.id" />
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
        value: [5000],
      },
      centrumDistance: {
        value: [800],
      },
      pool: true,
      nightEntertainment: true,
      childClub: true,
      restaurant: false,
           
    };
  },
  

  computed:{
      
       searchResults(){
            return this.$store.state.seachResults;
        },
        hotelsCount(){
            return this.filteredHotels.length;
        },

    filteredHotels() {
      let result = this.searchResults.filter(
        (hotel) => hotel.beachDistance <= this.beachDistance.value
      );
      result = result.filter(
        (hotel) => hotel.centrumDistance <= this.centrumDistance.value
      );
      
      if(this.pool){

        result = result.filter(
          (hotel) => hotel.pool == this.pool
        );
      }

       if(this.nightEntertainment){
        result = result.filter(
          (hotel) => hotel.nightEntertainment == this.nightEntertainment
        );
      }
      if(this.childClub){
        result = result.filter(
          (hotel) => hotel.childClub == this.childClub
        );
      }
      if(this.restaurant){
        result = result.filter(
          (hotel) => hotel.restaurant == this.restaurant
        );
      }
      return result
      console.log('hshsjjds');
    },
  }
 
};
</script>

<style src="@vueform/slider/themes/default.css">

</style>

<style scoped>
.myContainer{
    width: 300%;
    height: auto;
    margin: 10px;
    padding: 10px;
    display: grid;
}
.hotelResults{
  width: 30%;
    height: fit-content;
    margin: auto;
    margin-right: 5px;
}
.myFilter{
    width: 101%;
    margin-left: 5px;
    position: absolute;
}
  #sliders{
    color:rgb(255, 255, 255);
    
  }

  .accordion {
    color:black;
  }
  .slider-connect {
    background: #5a3ff5;
    cursor: pointer;
}

</style>
