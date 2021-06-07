<template>
    <div class="row">
        <div class="float-child">
          <Skeleton width="230px" height="130px" />
        </div>
        <div class="float-child">
          <Skeleton :width="randomNameLength + 'px'" height="30px"/>
          <Skeleton width="130px" height="10px" style="margin-top: 10px;"/>
          <Skeleton width="60px" height="10px" style="margin-top: 20px;"/>
          <Skeleton width="100px" height="10px" style="margin-top: 20px;"/>
          <Skeleton width="120px" height="10px" style="margin-top: 20px;"/>
        </div>
        <div class="float-child2">
          <Skeleton width="100px" height="30px"/>
          <Skeleton :width="randomEntertainmentLength1 + 'px'" height="10px" style="margin-top: 30px;"/>
          <Skeleton :width="randomEntertainmentLength2 + 'px'" height="10px" style="margin-top: 30px;"/>
          <Skeleton :width="randomEntertainmentLength3 + 'px'" height="10px" style="margin-top: 30px; margin-bottom: 10px;"/>
        </div>
        <hr>
    </div>
</template>
<script>
import Skeleton from 'primevue/skeleton';
export default {
    components:{
        Skeleton,
    },
    computed: {
        randomNameLength(){
            return (Math.random() * (180 - 130) + 130).toString();
        },
        randomEntertainmentLength1(){ // Workaround to get 3 random values from computed
            return (Math.random() * (70 - 30) + 30).toString();
        },
        randomEntertainmentLength2(){
            return (Math.random() * (70 - 30) + 30).toString();
        },
        randomEntertainmentLength3(){
            return (Math.random() * (70 - 30) + 30).toString();
        }
    },
}
</script>
<style>
.float-child {
    width: 37%;
    float: left;
}  
.float-child2 {
    width: 25%;
    float: left;
} 
</style>