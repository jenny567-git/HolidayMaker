<template>
    <div>
        <h1>test</h1>
        <BookedHotel v-for="hotel in bookedHotels" :hotel="hotel"></BookedHotel>
    </div>
</template>
<script>
import BookedHotel from './BookedHotel.vue'
export default {
    components:{
        BookedHotel,
    },
    created(){
        // Get booked hotels
        this.$store.dispatch('getBookings');
    },
    computed:{
        bookedHotels(){
            return this.$store.state.bookedHotels;
        }
    }
}
</script>
<style lang="">
    
</style>