// https://jsfiddle.net/setw7kn0/
<template>    
<div class="container">
  <div class="row">
    <div class="col-md-12">     
    <div id="dynamic_slide_show" class="carousel slide light-shadow carousel-fade carousel-thumbnails" data-ride="carousel">
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#dynamic_slide_show" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1">
                <img class="d-block w-200 img-fluid" src="https://i.imgur.com/Rpxx6wU.jpg">
            </button>
            <button type="button" data-bs-target="#dynamic_slide_show" data-bs-slide-to="1" aria-label="Slide 2">
                <img class="d-block w-200 img-fluid" src="https://i.imgur.com/83fandJ.jpg">
                </button>
            <button type="button" data-bs-target="#dynamic_slide_show" data-bs-slide-to="2" aria-label="Slide 3">
                <img class="d-block w-200 img-fluid" src="https://i.imgur.com/JiQ9Ppv.jpg">
            </button>
            <button type="button" data-bs-target="#dynamic_slide_show" data-bs-slide-to="3" aria-label="Slide 4">
                <img class="d-block w-200 img-fluid" src="https://i.imgur.com/weXVL8M.jpg">
            </button>
        </div>
      <div class="carousel-inner">
          <div class="carousel-item active">
              <img src="https://i.imgur.com/Rpxx6wU.jpg" class="d-block w-100" />
          </div>
          <div class="carousel-item">
                <img src="https://i.imgur.com/83fandJ.jpg" class="d-block w-100" />
           </div>
           <div class="carousel-item">
                <img src="https://i.imgur.com/JiQ9Ppv.jpg" class="d-block w-100" />
           </div>   
           <div class="carousel-item">
                <img src="https://i.imgur.com/weXVL8M.jpg" class="d-block w-100" />
           </div>     
       </div>
        <button  class="carousel-control-prev" type="button" data-bs-target="#dynamic_slide_show" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button >
        <button  class="carousel-control-next" type="button" data-bs-target="#dynamic_slide_show"  data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button >
  </div>                
  </div>
  </div>
  <hr>
</div>

</template>

<script>
import Images from './RoomPhotoSlider.vue'

export default {
components: {
    Images
  }
}
</script>