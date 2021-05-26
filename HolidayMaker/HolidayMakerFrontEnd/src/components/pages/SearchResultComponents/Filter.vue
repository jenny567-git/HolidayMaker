<template>
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
        v-model="beachRange.value"
        v-bind="beachRange"
        :max="5000"
      ></Slider>
    </div>
    <hr />
    <div>
      <p>Distance to city (km)</p>
      <Slider v-model="cityRange.value" v-bind="cityRange" :max="5000"></Slider>
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
</template>

<script>
// code: https://www.vuescript.com/custom-range-slider/
import Slider from "/node_modules/@vueform/slider";

export default {
  components: {
    Slider,
  },
  data() {
    return {
      pricerange: {
        value: [0, 40000],
      },
      beachRange: {
        value: [0],
      },
      cityRange: {
        value: [0],
      },
    };
  },
};
</script>

<style src="@vueform/slider/themes/default.css"></style>

<style scoped>
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
