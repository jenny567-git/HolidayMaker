<template>
    <div>
        <div class="row">
            <div class="col-md-4">
                <Images/>
            </div>
            <div class="col-md-8">
                <b>(hotel name)</b>
                <p>(3535) SEK</p>
                <p>Ratings: <span class="badge rounded-pill bg-secondary">(AverageRating)</span></p>
                
                <router-link :to="'/hotels/1'" class="nav-link"> 
                    <input type="checkbox" class="btn-check" id="btn-check-outlined" autocomplete="off">
                </router-link>
                <label class="btn btn-outline-primary" for="btn-check-outlined">See details</label><br>

                <!-- <div v-if="ShowInfo() == true">
                    <Info/>   
                </div> -->
                <!-- <button type="button" class="btn btn-primary">See details</button> -->
            </div>
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
  }
}
</script>