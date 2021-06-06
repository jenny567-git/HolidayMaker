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
    props:[]
      
}; 
</script>