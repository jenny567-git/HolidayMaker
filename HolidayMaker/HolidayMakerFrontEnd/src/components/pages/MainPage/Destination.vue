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
    *, *:before, *:after{
  margin: 0;
  padding: 0;
  -webkit-box-sizing: border-box;
  -moz-box-sizing:border-box;
  box-sizing: border-box;
}

.clickable{
   cursor: pointer;
   height: 100%;
}

.main-title{
  color: #2d2d2d;
  text-align: center;
  text-transform: capitalize;
  padding: 0.7em 0;
}

@media screen and (max-width: 640px){
  .container{
    display: block;
    width: 100%;
  }
}

@media screen and (min-width: 900px){
  .container{
    width: 33.33333%;
  }
}


.content {
  position: relative;
  width: 100%;
  max-width: 400px;
  margin: auto;
  overflow: hidden;
  height: 100%;
}

.content .content-overlay {
  background: linear-gradient(180deg, rgba(255,255,255,0) 25%, rgba(0,0,0,1) 100%);
  position: absolute;
  height: 100%;
  width: 100%;
  left: 0;
  top: 0;
  bottom: 0;
  right: 0;
  opacity: 0;
  -webkit-transition: all 0.4s ease-in-out 0s;
  -moz-transition: all 0.4s ease-in-out 0s;
  transition: all 0.4s ease-in-out 0s;
}

.content:hover .content-overlay{
  opacity: 1;
}

.content-image{
  width: 100%;
  height: 100%;
  object-fit: cover;
}

.content-details {
  position: absolute;
  text-align: center;
  padding-left: 1em;
  padding-right: 1em;
  width: 100%;
  top: 50%;
  left: 50%;
  opacity: 0;
  -webkit-transform: translate(-50%, -50%);
  -moz-transform: translate(-50%, -50%);
  transform: translate(-50%, -50%);
  -webkit-transition: all 0.3s ease-in-out 0s;
  -moz-transition: all 0.3s ease-in-out 0s;
  transition: all 0.3s ease-in-out 0s;
}

.content:hover .content-details{
  top: 70%;
  left: 50%;
  opacity: 1;
}

.content-details h3{
  color: #fff;
  font-weight: 500;
  letter-spacing: 0.15em;
  margin-bottom: 0.5em;
  text-transform: uppercase;
}

.content-details p{
  color: #fff;
  font-size: 0.8em;
}

.fadeIn-bottom{
  top: 80%;
}

.fadeIn-top{
  top: 20%;
}

.fadeIn-left{
  left: 20%;
}

.fadeIn-right{
  left: 80%;
}
</style>