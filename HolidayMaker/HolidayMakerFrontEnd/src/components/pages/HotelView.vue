<template>
    <Card id="test4">
        <template #content>
            <div class="hotelview">
                <h1>{{hotel.name}}</h1>
                <div class="container-fluid">
                    <PhotoG :photos="hotelImage"></PhotoG>
                    <div class="row">
                        <div class="col-md-12 buttons">
                            <ul class="nav nav-pills">
                                <div class="btn-group" role="group" aria-label="Basic example">
                                        <Button  id="fuckyB" label="Info" icon="pi pi-info-circle" @click="$router.push('/hotels/' + this.$route.params.id + '/')" ></Button>
                                        <Button  id="fuckyB" label="Photos" icon="pi pi-images" @click="$router.push('/hotels/' + this.$route.params.id + '/photos')"></Button>
                                        <Button  id="fuckyB" label="Reviews" icon="pi pi-comments" @click="$router.push('/hotels/' + this.$route.params.id + '/reviews')"></Button>
                                        <Button  id="fuckyB" label="Rooms" icon="pi pi-home" @click="$router.push('/hotels/' + this.$route.params.id + '/rooms')"></Button>
                                </div>
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
    </Card>
</template>

<style>
        #test4{
            margin-top: 30px;
            border-radius: 20px;
         }

        .hotelview h1{
            padding-bottom: 30px;
            font-family:'Times New Roman', Times, serif;
            font-weight: bold;
            text-decoration:underline;
        }

        #fuckyB{
           margin-right:5px;
            height:45px;
            background: #53c16e;
            border:#14a04d;
        }

        #fuckyB:enabled:hover{
            background:#348047 !important;
            border-color:#14a04d;
        }

        .col-md-12.buttons{
            border-top: 1px solid black;
            border-bottom: 1px solid black;
            padding-top:15px;
            padding-bottom:10px;
            margin-left:px;
            color:white;
        }

        .btn-group a{ 
            color:white !important;
            text-decoration: none !important;
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
import Photos from "./HotelViewComponents/Photos.vue"
import Button from 'primevue/button';
import PhotoG from "./HotelViewComponents/RoomsViewComponents/PhotoSlider.vue"
import Card from 'primevue/card';

export default ({
    components:{
        Info,
        Photos,
        Button,
        PhotoG,
        Card,    
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
        hotelImage(){
            return [{id: this.hotel.id, roomPhoto: this.hotel.img}]
        }
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
            fetch('https://localhost:44356/api/Guest/GetSavedHotels/' + this.$store.state.user.id)
                .then(response => response.json())
                .then(result => {
                    if(result){
                        // console.log("result",result);
                        console.log(this.hotel, this.hotelInfo);
                        for (let i = 0; i < result.length; i++) {
                            // console.log(result[i].hotelId, this.hotelInfo )
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
