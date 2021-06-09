<template>
    <div>
         <SavedHotel v-for="hotel in SavedHotels" :hotel="hotel" @delete-saved="deleteSaved" :key="hotel.hotelId"/>
    </div>
</template>
<script>
import SavedHotel from './SavedHotel.vue';

export default {
    components:{
        SavedHotel,
    },
    created(){
        // Get hotels
        console.log("gettings saved hotels");
        this.$store.dispatch('getSavedHotelsInfo');
        // this.SavedHotels = this.$store.state.savedHotels
    },
    data(){
        return{
            savedHotelsList: []
        }
    },
    computed:{
        SavedHotels(){
            return this.$store.state.savedHotels
        }
    }, 
    methods:{
        deleteSaved(id){
            console.log(id);
            this.$store.dispatch('removeFavouriteHotel', id)
            this.SavedHotels.filter((hotel) => hotel.hotelId !== id);
            // console.log('saved hotels now '. this.savedHotelsList);
        }
    }
}
</script>
<style lang="">
    
</style>