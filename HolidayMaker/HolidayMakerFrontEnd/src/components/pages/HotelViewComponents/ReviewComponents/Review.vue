<template>
    <div class="p-4 rounded shadow-sm">
      <div class="row">
        <div class="row">
          <div class="col-md-4">
            <p>Name: {{review.guest.fullName}}</p>
            <p>Date created: {{ createdDate }}</p>
            <!-- <p>Language: (English)</p> -->
          </div>
          <div class="col-md-8">
            <p>
              Ratings:
              <span class="badge rounded-pill bg-secondary">{{
                review.rating
              }}</span>
            </p>
            <p>{{ review.description }}</p>
          </div>
        </div>
      </div>
    </div>
</template>



<script>
export default {
  props: {
    review: {},
  },
  computed:{
        createdDate(){
                // console.log('this review', this.review)
                let date = new Date(this.review.creationDate).toISOString().slice(0,10);
                // console.log('this date', date)
                return date;
        },
  }
};
</script>

<style scoped>
.p-4{
        margin-top:15px;
        background-color:rgb(241, 241, 241);
    }
</style>