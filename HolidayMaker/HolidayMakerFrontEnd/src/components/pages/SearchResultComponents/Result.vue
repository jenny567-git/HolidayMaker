<template>
    <div id="test3">
        <div class="row">
            <div class="col-md-4">
                <Images :id="hotel.id"/>
            </div>
            <div class="col-md-8">
                <b>{{hotel.name}}</b>
                <p>(3535) SEK</p>
                <p>Ratings: <span class="badge rounded-pill bg-secondary">{{hotel.averageRating}}</span></p>
                <p v-if="hotel.pool"> <i class="fas fa-check"></i> Pool</p>
                <p v-if="hotel.nightEntertainment"> <i class="fas fa-check"></i> Night Entertainment</p>
                <p v-if="hotel.childClub"> <i class="fas fa-check"></i> Kids club</p>
                <p v-if="hotel.restaurant"> <i class="fas fa-check"></i> Restaurant</p>
                <router-link :to="'/hotels/' + hotel.id" class="nav-link"> 
                    <button class="btn btn-outline-primary" for="btn-check-outlined" @click="hotelDetailsClick">See details</button><br>
                </router-link>

            </div>
        </div>
        <hr>
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
      hotel:{}
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