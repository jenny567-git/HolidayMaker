<template>
    <div id="test3">
        <div class="row" >
            <div class="col-md-4">
                <Images :id="hotel.id"/>
            </div>
            <div class="col-md-8">
                <div class="row">
                    <div class="col-md-6 text-start">
                        <b>{{hotel.name}}</b>
                        <p>{{hotel.city.cityName}}, {{hotel.country.countryName}}</p>
                        <p>Ratings: <span class="badge rounded-pill bg-secondary">{{hotel.averageRating}}</span></p>
                        <p>Beach distance: <span class="badge rounded-pill bg-secondary">{{hotel.beachDistance}} m </span></p>
                        <p>Centrum distance: <span class="badge rounded-pill bg-secondary">{{hotel.centrumDistance}} km </span></p>
                    </div>
                    <div class="col-md-6 text-start">
                        <h3>{{lowestPrice}} SEK</h3>
                        <br/>
                        <p v-if="hotel.pool"> <i class="fas fa-check"></i> Pool</p>
                        <p v-if="hotel.nightEntertainment"> <i class="fas fa-check"></i> Night Entertainment</p>
                        <p v-if="hotel.childClub"> <i class="fas fa-check"></i> Kids club</p>
                        <p v-if="hotel.restaurant"> <i class="fas fa-check"></i> Restaurant</p>
                    </div>
                </div>
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
computed:{
    lowestPrice(){
        var rooms = this.hotel.rooms;
        rooms.sort((a,b) => {
            return a.price - b.price
        })
        var min = rooms[0]
        return min.price;
      }
},
 props:{
     hotel:{}
 },
  methods:{
      hotelDetailsClick(event){
          console.log("Set hotel in result", this.hotel.id)
          this.$store.dispatch('setHotel', this.hotel)
      },
      
  }
}
</script>

<style scoped>
    #test3{
        opacity: 100% !important;
    }
</style>