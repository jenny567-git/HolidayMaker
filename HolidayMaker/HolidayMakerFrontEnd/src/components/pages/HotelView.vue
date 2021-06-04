<template>
    <div id="test2" class="hotelview">
        <h1>{{hotel.name}}</h1>
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-4 twopic"> <!-- Stacked images -->
                    <div>
                        <img class="img-fluid" src="https://storage.googleapis.com/static-content-hc/sites/default/files/cataloina_porto_doble_balcon2_2.jpg" alt="">
                    </div>
                    <div>
                        <img class="img-fluid" src="https://storage.googleapis.com/static-content-hc/sites/default/files/cataloina_porto_doble_balcon2_2.jpg" alt="">
                    </div>
                </div>
                <div class="col-md-8 onepic"> <!-- Main image -->
                    <div>
                        <img class="img-fluid" src="https://media-cdn.tripadvisor.com/media/photo-s/16/1a/ea/54/hotel-presidente-4s.jpg" alt="">
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 buttons">
                    <ul class="nav nav-pills">
                        <div class="btn-group" role="group" aria-label="Basic example">
                            <button type="button" class="btn btn-primary"><router-link :to="'/hotels/' + this.$route.params.id + '/'" class="nav-link" > Info </router-link></button>
                            <button type="button" class="btn btn-primary"><router-link :to="'/hotels/' + this.$route.params.id + '/photos'" class="nav-link"> Photos </router-link></button>
                            <button type="button" class="btn btn-primary"><router-link :to="'/hotels/' + this.$route.params.id + '/reviews'" class="nav-link"> Reviews </router-link></button>
                            <button type="button" class="btn btn-primary"><router-link :to="'/hotels/' + this.$route.params.id + '/rooms'" class="nav-link"> Rooms </router-link></button>
                        </div>
                        <!-- <li class="nav-item">
                            <router-link :to="'/hotels/' + this.$route.params.id + '/'" class="nav-link" > Info </router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/hotels/' + this.$route.params.id + '/photos'" class="nav-link"> Photos </router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/hotels/' + this.$route.params.id + '/reviews'" class="nav-link"> Reviews </router-link>
                        </li>
                        <li class="nav-item">
                            <router-link :to="'/hotels/' + this.$route.params.id + '/rooms'" class="nav-link"> Rooms </router-link>
                        </li> -->
                        <li class="nav-item">
                            <button class="btn" @click="ToggleStar" id="starBtn">
                                <i :class="star ? 'fas fa-heart fa-2x' : 'far fa-heart fa-2x'" style="color: red;"></i>
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
            background-color: white;
            padding-left: 25px;
            padding-right: 25px;
            padding-bottom: 40px;
            margin-top: 20px;
            color:rgb(0, 0, 0);
        }

        .hotelview h1{
        }


        .col-md-4.twopic{
            padding-bottom: 10px;
        }

        .col-md-8.onepic{
        }

        .col-md-12.buttons{
            border-top: 1px solid black;
            border-bottom: 1px solid black;
            padding-top:15px;
            padding-bottom:15px;
        }

        button.btn.btn-primary{
            background: #43744f;
            border-color:rgb(0, 0, 0);
        }

        .nav-link:focus, .nav-link:hover {
             color: #4d915e;
        }

        .nav.nav-pills a:hover{
            color:rgb(51, 161, 78);
        }

        .nav.nav-pills a:hover ::before{
            color:rgb(51, 161, 78);
        }


        .nav.nav-pills{
            margin-left: 8cm;
        }

        .nav-link{
            color:rgb(255, 255, 255);
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
