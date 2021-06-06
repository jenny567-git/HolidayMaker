<template>
<CarouselCard :interval="7000" height="300px" type="card" arrow="always">
    <CarouselCardItem v-for="i in 6" :key="i">
        <h1 v-text="i"></h1>
    </CarouselCardItem>
</CarouselCard>
</template>


<script>
import Galleria from 'primevue/galleria';
import { CarouselCard, CarouselCardItem } from 'vue-carousel-card'
import 'vue-carousel-card/styles/index.css'


export default {

     components: {
      Galleria,
      CarouselCard,
      CarouselCardItem,
  },
    props:[
       
    // initialIndex: { 
    // type: Number, 
    // default: 0
    // },

    // height: { 
    // type: String,
    // default: '200', 
    // },

    // trigger: { 
    // type: String, 
    // default: 'hover' 
    // },

    // autoplay: { 
    // type: Boolean, 
    // default: true 
    // },

    // interval: { 
    // type: Number, 
    // default: 3000 
    // },

    // indicatorPosition: { 
    // type: String, 
    // default: 'outside' // outside/none
    // },

    // indicator: { 
    // type: Boolean, 
    // default: true 
    // },

    // arrow: { 
    // type: String, 
    // default: 'hover' // always/hover/never
    // },

    // type: String // card
    // label: {
    // type: [String, Number],
    // default: ''
    // }
        ]
        
}; 
</script>