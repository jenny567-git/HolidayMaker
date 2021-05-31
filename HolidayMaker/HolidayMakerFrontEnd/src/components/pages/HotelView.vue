<template>
    <div id="test2">
        <h1>{{hotel.name}}</h1>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4"> <!-- Stacked images -->
                    <div>
                        <img class="img-fluid" src="https://storage.googleapis.com/static-content-hc/sites/default/files/cataloina_porto_doble_balcon2_2.jpg" alt="">
                    </div>
                    <div>
                        <img class="img-fluid" src="https://storage.googleapis.com/static-content-hc/sites/default/files/cataloina_porto_doble_balcon2_2.jpg" alt="">
                    </div>
                </div>
                <div class="col-md-8 "> <!-- Main image -->
                    <div>
                        <img class="img-fluid" src="https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg" alt="">
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <ul class="nav nav-pills">
                        <li class="nav-item">
                            <router-link :to="'/hotels/' + this.$route.params.id + '/'" class="nav-link active"> Info </router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/hotels/' + this.$route.params.id + '/photos'" class="nav-link"> Photos </router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/hotels/' + this.$route.params.id + '/reviews'" class="nav-link"> Reviews </router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/hotels/' + this.$route.params.id + '/rooms'" class="nav-link"> Rooms </router-link>
                        </li>
                        
                    </ul>
                </div>
            </div>
            <div> <!-- tab view -->
                <router-view></router-view>
            </div>
        </div>
    </div>
</template>

<style>
    #test2{
            border-radius: 30px;
            background-color: rgba(107, 146, 83, 0.5);
            padding-left: 25px;
            padding-right: 25px;
            padding-bottom: 40px;
            margin-top: 20px;
            color:white;
        }

        .nav-link{
            color:white;
        }
</style>

<script>
import Info from './HotelViewComponents/Info.vue'
export default ({
    components:{
        Info,
    },
    data(){
        return{
            hotelInfo:{}
        }
    },
    computed:{
        hotel(){ 
            return this.$store.state.hotel;
        }
    },
    created() {
        if(!this.$store.state.seachResults.length){
            this.$store.dispatch('getHotelById', this.$route.params.id)
        }
        
  }
})
</script>
