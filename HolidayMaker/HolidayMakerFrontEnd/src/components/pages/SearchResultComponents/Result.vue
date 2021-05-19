<template>
    <div>
        <div class="row">
            <div class="col-md-4">
                <Images/>
            </div>
            <div class="col-md-8">
                <b>{{hotel.name}}</b>
                <p>(3535) SEK</p>
                <p>Ratings: <span class="badge rounded-pill bg-secondary">{{hotel.averageRating}}</span></p>
                
                <router-link :to="'/hotels/' + hotel.id" class="nav-link"> 
                    <label class="btn btn-outline-primary" for="btn-check-outlined">See details</label><br>
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
  }
}
</script>