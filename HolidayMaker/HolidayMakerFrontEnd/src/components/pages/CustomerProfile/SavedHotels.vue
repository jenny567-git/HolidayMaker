<template>
    <div>
        <div v-if="SavedHotels.length < 1 && !errorText">
            <ProgressSpinner />
        </div>
        <div v-if="errorText">
            <p>No saved hotels found. Click the heart at the hotel page for them to show up here!</p>
        </div>
         <SavedHotel v-for="hotel in SavedHotels" :hotel="hotel" @delete-saved="deleteSaved" :key="hotel.hotelId"/>
    </div>
</template>
<script>
import SavedHotel from './SavedHotel.vue';
import ProgressSpinner from 'primevue/progressspinner';
export default {
    data(){
        return{
            errorText: false,
            // SavedHotels: []
        }
    },
    components:{
        SavedHotel,
        ProgressSpinner,
    },
    async created(){
        // Get hotels
        console.log("gettings saved hotels");
        await this.$store.dispatch('getSavedHotelsInfo');

        if(!this.SavedHotels.length){
            this.errorText = true;
        }
        
    },
    data(){
        return{
            savedHotelsList: []
        }
    },
    computed:{
        SavedHotels(){
            return this.$store.state.savedHotels || [];
        }
    }, 
    methods:{
        deleteSaved(id){
            console.log(id);
            this.$store.dispatch('removeFavouriteHotel', id)
            this.SavedHotels.filter((hotel) => hotel.hotelId !== id);
            // console.log('saved hotels now '. this.savedHotelsList);
        }
    },
    unmounted(){
        // console.log("destroy");
    }
}
</script>
<style lang="">
    
</style>