<template>
    <div class="col-lg-4 mb-3">
        <div class="content">
            <!-- <a href="https://unsplash.com/photos/HkTMcmlMOUQ" target="_blank"> -->
            <div class="clickable" @click="searchDestination">

              <div class="content-overlay"></div>
              <img class="content-image" :src="destination.img">
              <div class="content-details fadeIn-bottom">
                  <h3 class="content-title">{{destination.title}}</h3>
                  <p class="content-text">{{destination.description}}</p>
              </div>
            </div>
            <!--</a>-->
        </div>
    </div>
</template>
<script>
export default {
    props:{
        destination:{}
    },
    methods:{
      searchDestination(){
        //console.log("search destination");
        this.$store.dispatch('searchSpecific', {type: 'city', searchString: this.destination.title});
      }
    }
}
</script>
<style >


.content-image{
  width: 10%;
  height: 10%;
  object-fit: cover;
}


</style>