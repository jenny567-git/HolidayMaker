<template>
  <div>
    <div class="row pt-5">
      <div class="col-md-10">
        <h2>Guest reviews</h2>
      </div>
      <div class="col-md-2 text-end">
        <router-link :to="addReviewLink" class="btn btn-primary">
          Add review
        </router-link>
      </div>
    </div>
    <hr />
    <div class="row pb-3">
      <div class="col-md-12">
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
            <li>
              <a
                v-on:click="ratingFilterKey = 'all'"
                :class="'dropdown-item ' + { active: ratingFilterKey == 'all' }"
                >All</a
              >
            </li>
            <li>
              <a
                v-on:click="ratingFilterKey = 'only4'"
                :class="
                  'dropdown-item ' + { active: ratingFilterKey == 'only4' }
                "
                >4+</a
              >
            </li>
            <li>
              <a
                v-on:click="ratingFilterKey = 'only3'"
                :class="
                  'dropdown-item ' + { active: ratingFilterKey == 'only3' }
                "
                >3+</a
              >
            </li>
            <li>
              <a
                v-on:click="ratingFilterKey = 'below3'"
                :class="
                  'dropdown-item ' + { active: ratingFilterKey == 'below3' }
                "
                >Below 3</a
              >
            </li>
          </ul>
        </div>
      </div>
    </div>
    <div class="row">
      <Review
        v-for="review in ratingFilterList"
        :review="review"
        :key="review.id"
      />
    </div>
  </div>
</template>

<style scoped>
.btn.btn-primary {
  background-color: #53c16e;
  border-color: #1bc541;
}

h2 {
  margin-left: 5cm;
}

.dropdown {
  margin-left: 25cm;
}

.active {
  font-weight: bold;
}
</style>


<script>
import Review from "./ReviewComponents/Review.vue";
export default {
  components: {
    Review,
  },
  mounted() {
    this.getReviews(this.$route.params.id);
  },
  data() {
    return {
      ratingFilterKey: "all",
      allreviews: undefined,
      addReviewLink: "/hotels/" + this.$route.params.id + "/addReview",
    };
  },
  computed: {
    ratingFilterList() {
      return this[this.ratingFilterKey];
    },
    all() {
      return this.allreviews;
    },
    only4() {
      return this.allreviews.filter((user) => user.rating >= 4);
    },
    only3() {
      return this.allreviews.filter((user) => user.rating >= 3);
    },
    below3() {
      return this.allreviews.filter((user) => user.rating < 3);
    },
  },
  methods: {
    getReviews(hotelId) {
      fetch("https://localhost:44356/api/Hotel/GetReviews/" + hotelId)
        .then((response) => response.json())
        .then((result) => {
          //sort by latest date first
          this.allreviews = result.sort((x, y) => {
            let a = new Date(x.creationDate),
              b = new Date(y.creationDate);
            return b - a;
          });
        });
    },
  },
};
</script>