<template>
  <div class="container">
    <h1>Popular Destinations</h1>
    <div class="row my-5">
      <div class="col-lg-12 mx-auto">
        <div class="row">
          
        <Destination v-for="destination in popularDestinations" :destination="destination" :key="destination.title"/>

        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Destination from './Destination.vue'
export default {
  components:{
    Destination
  },
  data(){
    return{
      popularDestinations:[{
        title: 'Lefkos',
        description: 'See available hotels in Lefkos',
        img: 'https://bilder.apollo.se/three-dolphins-1557016426-110210-ImageGalleryLightbox.jpg',
        searchQuery: ''
      },
      {
        title: 'London',
        description: 'See available hotels in London',
        img: 'https://blog.fly.deals/wp-content/uploads/2020/06/London_Tower_Bridge_City.jpg',
        searchQuery: ''
      },
      {
        title: 'Berlin',
        description: 'See available hotels in Berlin',
        img: 'https://media.radissonhotels.net/image/destination-pages/localattraction/16256-118729-f63244989_3xl.jpg?impolicy=HomeHero',
        searchQuery: ''
      },
      {
        title: 'Copenhangen',
        description: 'See available hotels in Copenhangen',
        img: 'https://www.flytap.com/-/media/Flytap/new-tap-pages/destinations/europe/denmark/copenhagen/destinations-copenhagen-banner-mobile-1024x553.jpg',
        searchQuery: ''
      },
      {
        title: 'Cape Town',
        description: 'See available hotels in South Africa',
        img: 'https://foto.hrsstatic.com/fotos/0/3/1090/700/80/000000/http%3A%2F%2Ffoto-origin.hrsstatic.com%2Ffoto%2F3%2F5%2F1%2F7%2F351788%2F351788_a_13291718.jpg/mB04g2nLq58aw%2FS0i36ycA%3D%3D/2896,2914/6/The_Table_Bay-Cape_Town-Exterior_view-3-351788.jpg',
        searchQuery: ''
      },
      {
        title: 'Cairo',
        description: 'See available hotels in Egypt',
        img: 'https://i.middle-east-online.com/styles/home_special_coverage_1920xauto/s3/2020-08/fairmont%20hotel%20cairo.jpg?3DRH75K8aS2dza_mlE9YA0RsEo3L3l7k&itok=ARlc1LW6',
        searchQuery: ''
      },
      ]
    }
  }
}
</script>



<style>
*, *:before, *:after{
  margin: 0;
  padding: 0;
  -webkit-box-sizing: border-box;
  -moz-box-sizing:border-box;
  box-sizing: border-box;
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

.container .title{
  color: #1a1a1a;
  text-align: center;
  margin-bottom: 10px;
}

.content {
  position: relative;
  width: 100%;
  max-width: 400px;
  margin: auto;
  overflow: hidden;
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
