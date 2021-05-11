<template>
    <div>
        <div class="row">
            <div class="col-md-4">
                <Images/>
            </div>
            <div class="col-md-8">
                <b>(hotel name)</b>
                <p>3535 SEK</p>
                <p>Ratings: (AverageRating)</p>
                
                <button type="button" class="btn btn-primary">See details</button>
            </div>
        </div>
    </div>
</template>

<script>
import Images from '../HotelViewComponents/RoomPhotoSlider.vue'

export default {
components: {
    Images
  }
}
</script>