<template>
    <div>
        <div v-if="SavedHotels.length < 1 && !errorText">
            <ProgressSpinner />
        </div>
        <div v-if="errorText">
            <p>No saved hotels found. Click the heart at the hotel page for them to show up here!</p>
        </div>
        <SavedHotel v-for="hotel in SavedHotels" :hotel="hotel" />
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

        if(!that.SavedHotels.length){
            that.errorText = true;
        }
        
    },
    computed:{
        SavedHotels(){
            return this.$store.state.savedHotels || [];
        }
    },
    unmounted(){
        // console.log("destroy");
    }
}
</script>
<style lang="">
    
</style>