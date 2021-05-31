<template>
  <div>
    <div class="row">
      <div class="row">
        <div class="col-md-4">
          <p>Name: (firstname lastname) GuestID: {{ review.guestId }}</p>
          <p>Date created: {{ review.creationDate }}</p>
          <p>Language: (English)</p>
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
      <hr />
    </div>
  </div>
</template>



<script>
export default {
  props: {
    review: {},
  },
};
</script>

<style>
</style>