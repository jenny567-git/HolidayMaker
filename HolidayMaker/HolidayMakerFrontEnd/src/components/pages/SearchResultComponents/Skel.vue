<template>
    <div class="row">
        <div class="float-child">
          <Skeleton width="90%" height="80%" />
        </div>
        <div class="float-child">
          <Skeleton :width="randomNameLength + '%'" height="30px"/>
          <Skeleton width="50%" height="10px" style="margin-top: 10px;"/>
          <Skeleton width="22%" height="10px" style="margin-top: 20px;"/>
          <Skeleton width="40%" height="10px" style="margin-top: 20px;"/>
          <Skeleton width="50%" height="10px" style="margin-top: 20px;"/>
        </div>
        <div class="float-child2">
          <Skeleton width="62%" height="30px"/>
          <Skeleton :width="randomEntertainmentLength1 + '%'" height="10px" style="margin-top: 30px;"/>
          <Skeleton :width="randomEntertainmentLength2 + '%'" height="10px" style="margin-top: 30px;"/>
          <Skeleton :width="randomEntertainmentLength3 + '%'" height="10px" style="margin-top: 30px; margin-bottom: 10px;"/>
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
            return (Math.random() * (80 - 60) + 50).toString();
        },
        randomEntertainmentLength1(){ // Workaround to get 3 random values from computed
            return (Math.random() * (45 - 20) + 20).toString();
        },
        randomEntertainmentLength2(){
            return (Math.random() * (45 - 20) + 20).toString();
        },
        randomEntertainmentLength3(){
            return (Math.random() * (45 - 20) + 20).toString();
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