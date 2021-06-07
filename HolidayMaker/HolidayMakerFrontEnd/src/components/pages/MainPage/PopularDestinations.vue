<template>
  <div class="container">
    <h1 id="pop">Popular Destinations</h1>
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
        title: 'Copenhagen',
        description: 'See available hotels in Copenhangen',
        img: 'https://www.flytap.com/-/media/Flytap/new-tap-pages/destinations/europe/denmark/copenhagen/destinations-copenhagen-banner-mobile-1024x553.jpg',
        searchQuery: ''
      },
      {
        title: 'The Table Bay Hotel',
        description: 'See available hotels in South Africa',
        img: 'https://foto.hrsstatic.com/fotos/0/3/1090/700/80/000000/http%3A%2F%2Ffoto-origin.hrsstatic.com%2Ffoto%2F3%2F5%2F1%2F7%2F351788%2F351788_a_13291718.jpg/mB04g2nLq58aw%2FS0i36ycA%3D%3D/2896,2914/6/The_Table_Bay-Cape_Town-Exterior_view-3-351788.jpg',
        searchQuery: ''
      },
      {
        title: 'Fairmont Nile City',
        description: 'See available hotels in Egypt',
        img: 'https://i.middle-east-online.com/styles/home_special_coverage_1920xauto/s3/2020-08/fairmont%20hotel%20cairo.jpg?3DRH75K8aS2dza_mlE9YA0RsEo3L3l7k&itok=ARlc1LW6',
        searchQuery: ''
      },
      ]
    }
  }
}
</script>



<style scoped>

h1{
  margin-top: 35px;
}

#pop{
  font-family:'Times New Roman', Times, serif;
  font-weight: bold;
  text-decoration:underline;
}
</style>
