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
                            <router-link :to="'/hotels/' + this.$route.params.id + '/'" class="nav-link"> Info </router-link>
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
                        <li class="nav-item">
                            <button class="btn" @click="ToggleStar" id="starBtn">
                                <i :class="star ? 'fas fa-heart' : 'far fa-heart'" style="color: red;"></i>
                            </button>
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
        #starBtn{
            outline: none;
            box-shadow: none;
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
            hotelInfo:{},
            star: false
        }
    },
    computed:{
        hotel(){ 
            return this.$store.state.hotel;
        },
    },
    methods:{
        ToggleStar(){
            if(this.star === false){
                // Set fav
                this.$store.dispatch('addFavouriteHotel', this.hotel.id)
                console.log(this.hotel.id)
                this.star = !this.star;
            }
            else{
                // Remove fav
                this.$store.dispatch('removeFavouriteHotel', this.hotel.id)
                this.star = !this.star;
            }
        },
        getSavedHotels(){ 
            fetch('https://localhost:44356/api/Guest/GetSavedHotels/' + this.$store.state.guestId)
                .then(response => response.json())
                .then(result => {
                    if(result){
                        console.log("result",result);
                        console.log(this.hotel, this.hotelInfo);
                        for (let i = 0; i < result.length; i++) {
                            console.log(result[i].hotelId, this.hotelInfo )
                            if(result[i].hotelId === this.hotel.id){
                                this.star = true;
                            }
                        }
                    }
            });
        }
    },
    watch:{
        hotelInfo: {
            handler: function(oldVal, newVal){
                console.log("Hotel info changed", this.hotelInfo);
                setTimeout(function(that){ 
                    console.log("call getsavedhotels");
                    that.getSavedHotels();
                }, 500, this);
            },
        }
    },
    created() {
        if(!this.$store.state.seachResults.length){
            this.$store.dispatch('getHotelById', this.$route.params.id)
        }
        
  
        this.$store.dispatch('getHotelById', this.$route.params.id)
        .then(() =>{
            console.log("Test somethng");
            this.getSavedHotels();
        });

        // setTimeout(function(that){ 
        //     that.getSavedHotels();
        // }, 1500, this);
    }
})
</script>
