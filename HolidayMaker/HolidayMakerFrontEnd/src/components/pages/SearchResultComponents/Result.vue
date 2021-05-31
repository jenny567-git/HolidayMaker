<template>

    <div id="test3">
        <div class="row">
            <Images :id="hotel.id"/>
                <b>{{hotel.name}}</b>
                <p>Distance to beach: {{hotel.beachDistance}}</p>
                
                <p>Ratings: <span class="badge rounded-pill bg-secondary">{{hotel.averageRating}}</span></p>

                <router-link :to="'/hotels/' + hotel.id" class="nav-link"> 
                    <button class="btn btn-outline-primary" for="btn-check-outlined" @click="hotelDetailsClick">See details</button><br>
                </router-link>

        <hr>
            </div>
        </div>
    
</template>

<script>
import Images from '../HotelViewComponents/RoomPhotoSlider.vue'
import Info from '../HotelViewComponents/Info.vue'


export default {
components: {
    Images,
    Info
  },
  
  props:{
    hotel: {}
  },

  computed:{
    myHotels(){
      return this.$store.state.hotels  
    },
    filteredHotels() {
      
      let result = this.hotel.filter(
        (hotel) => hotel.beachDistance <= this.beachRange.value
      );
      return result
    }
     
  },
  methods:{
      hotelDetailsClick(event){
          console.log("Set hotel", this.hotel.id)
          this.$store.dispatch('setHotel', this.hotel)
      }
  }
}
</script>

<style scoped>
    #test3{
        opacity: 100% !important;
    }
</style>