<template>
  <div>
    <div class="row pt-5">
      <div class="col-md-10">
        <h2>Guest reviews</h2>
      </div>
      <div class="col-md-2 text-end">
        <button type="button" class="btn btn-primary">Add review</button>
      </div>
    </div>
    <hr />
    <div class="row pb-3">
      <div class="col-md-4">
        <div class="dropdown">
          <button
            class="btn btn-secondary dropdown-toggle"
            type="button"
            id="reviewRatingDropdownMenu"
            data-bs-toggle="dropdown"
            aria-expanded="false"
          >
            Rating
          </button>
          <ul class="dropdown-menu" aria-labelledby="reviewRatingDropdownMenu">
            <li><a class="dropdown-item" href="#">4+</a></li>
            <li><a class="dropdown-item" href="#">3+</a></li>
            <li><a class="dropdown-item" href="#">2+</a></li>
            <li><a class="dropdown-item" href="#">All</a></li>
          </ul>
        </div>
      </div>
      <div class="col-md-8">
        <div class="dropdown text-end">
          <button
            class="btn btn-secondary dropdown-toggle"
            type="button"
            id="reviewLanguageDropdownMenu"
            data-bs-toggle="dropdown"
            aria-expanded="false"
          >
            Language
          </button>
          <ul
            class="dropdown-menu"
            aria-labelledby="reviewLanguageDropdownMenu"
          >
            <li><a class="dropdown-item" href="#">English</a></li>
            <li><a class="dropdown-item" href="#">Swedish</a></li>
          </ul>
        </div>
      </div>
    </div>
    <div class="row">
      <ReviewSubComp
        v-for="review in reviews"
        :review="review"
        :key="review.id"
      />
      <!-- <hr>
            <ReviewSubComp/>
            <hr>
            <ReviewSubComp/>
            <hr>
            <ReviewSubComp/> -->
    </div>
    <div class="row">
      <b>Pagination not working yet, only visual</b>
      <nav aria-label="Page navigation example">
        <ul class="pagination justify-content-center">
          <li class="page-item"><a class="page-link" href="#">Previous</a></li>
          <li class="page-item"><a class="page-link" href="#">1</a></li>
          <li class="page-item"><a class="page-link" href="#">2</a></li>
          <li class="page-item"><a class="page-link" href="#">3</a></li>
          <li class="page-item"><a class="page-link" href="#">Next</a></li>
        </ul>
      </nav>
    </div>
  </div>
</template>

<script>
import ReviewSubComp from "./ReviewComponents/ReviewSubComponent.vue";
export default {
  components: {
    ReviewSubComp,
  },
  mounted() {
    console.log(this.$route.params.id);
    this.getReviews();
  },
  data() {},
  computed: {
    reviews: {
      get() {
        return this.$store.state.getReviews;
      },
    },
  },
  methods: {
    getReviews() {
      this.$store.dispatch("getReviews", this.$route.params.id);
    },
  },
};
</script>