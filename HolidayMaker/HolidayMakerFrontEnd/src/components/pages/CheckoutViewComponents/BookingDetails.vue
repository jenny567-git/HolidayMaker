<template >
    <div>
        <h4 class="mb-3">Booking details</h4>
        <ul class="list-unstyled" id="BookingDetailsList">
            <li class="list-item">
                Rooms:
            </li>
            <li v-for="(room, index) in rooms" :key="index">
                <span v-if="room.nrOfRooms > 0">
                    {{room.type}} : {{room.nrOfRooms}}
                </span> 
            </li>
            <li class="list-item">
                Service type: {{serviceType}}
            </li>
            <li class="list-item">
                Extra bed: {{extraBed}}
            </li>
            <li class="list-item">
                Price: {{price}}
            </li>
        </ul>
    </div>
</template>

<script>
export default {
    computed:{
        rooms(){
            return this.$store.state.bookingDetails.rooms;
        },
        serviceType(){
            return this.$store.state.bookingDetails.serviceType;
        },
        extraBed(){
            return this.$store.state.bookingDetails.extraBed ? 'Yes' : 'No';
        },
        price(){
            return '$343';
        }
    }
}
</script>
<style scoped>
    #BookingDetailsList{
        display: inline-block;
        text-align: left;
    }
</style>