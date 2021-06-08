<template>
  <div class="py-4">
    <div class="p-4 bg-light rounded shadow-sm">
        <h5>Rating: <span class="badge rounded-pill bg-secondary">{{hotel.averageRating}}</span></h5>
        <p>{{hotel.description}}</p>
        <h4>Amentities:</h4>
        <div class="amentities">
          <p v-if="hotel.pool"> <i class="fas fa-check"></i> Pool</p>
          <p v-if="hotel.nightEntertainment"> <i class="fas fa-check"></i> Night Entertainment</p>
          <p v-if="hotel.childClub"> <i class="fas fa-check"></i> Kids club</p>
          <p v-if="hotel.restaurant"> <i class="fas fa-check"></i> Restaurant</p>
        </div>
    </div>
  </div>
</template>

<script>
export default {
  
  computed: {
    hotel() {
      return this.$store.state.hotel;
    },
  },
};
</script>

<style scoped>

 div{
   padding-top: 30px;
 }

 div.amentities{
   text-align:justify;
   margin-left:12cm;
 }
</style>