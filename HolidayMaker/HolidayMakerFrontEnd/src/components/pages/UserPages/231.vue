<template>
    <div id="test2">
        <h1>Saved Hotels view</h1>
        <SavedHotel v-for="hotel in SavedHotels" :hotel="hotel" />
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
        this.$store.dispatch('getSavedHotelsInfo');
        this.SavedHotels = this.$store.state.savedHotels
    },
    computed:{
        SavedHotels(){
            return this.$store.state.savedHotels;
        }
    }
}
</script>
<style >
    
</style>