<template>
  <div v-if="photoExists" :style="{width: width, height: height}" >
    <div :id="'carouselExampleFade' + photos[0].id" class="carousel slide carousel-fade" data-bs-ride="carousel">
      <div class="carousel-inner">
        <div class="active carousel-item">
          <img :src="photos[0].roomPhoto" class="d-block w-100 photoSlider" :style="{height: height}" alt="...">
        </div>
        <div class="carousel-item" v-for="(photo, index) in photos.slice(1)" :key="index">
          <img :src="photo.roomPhoto" class="d-block w-100 photoSlider" :style="{height: height}" alt="...">
        </div>
      </div>
      <button class="carousel-control-prev" type="button" :data-bs-target="'#carouselExampleFade' + photos[0].id" data-bs-slide="prev">
        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Previous</span>
      </button>
      <button class="carousel-control-next" type="button" :data-bs-target="'#carouselExampleFade' + photos[0].id" data-bs-slide="next">
        <span class="carousel-control-next-icon" aria-hidden="true"></span>
        <span class="visually-hidden">Next</span>
      </button>
    </div>
  </div>
</template>

<script>
export default {
  props:{
    photos: {
      type: [Object]
    },
    width: {
      type: String,
      default: ''
    },
    height:{
      type: String,
      default: ''
    }
  },
  created(){
  },
  computed:{
    photoExists(){
      return (this.photos.length !== undefined )|| this.photos ? true : false;
    },
  }
}
</script>

<style scoped>
  .photoSlider {
    object-fit: cover;
  }

  #carouselExampleFade{
      margin-bottom:15px;
      border-style:inset;
  }

  .carousel-inner{
    width:100%;
    max-height: 550px !important;
    /* min-height: 550px !important; */
  }
</style>