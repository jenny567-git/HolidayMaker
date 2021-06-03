<template>
  <div>
    <div class="row pt-5">
      <div class="col-md-10">
        <h2>Guest reviews</h2>
      </div>
      <div class="col-md-2 text-end">
        <router-link :to="'/hotels/' + this.$route.params.id + '/addReview'">
          <button type="button" class="btn btn-primary">Add review</button>
        </router-link>
      </div>
    </div>
    <hr />
    <div class="row pb-3">
      <div class="col-md-4">
        <!-- <div class="filter">
          <label><input type="radio" value="All" /> All</label>
          <label><input type="radio" value="4" /> 4</label>
          <label><input type="radio" value="3" /> 3</label>
          <label><input type="radio" value="2" /> 2</label>
        </div> -->
        <div class="dropdown">
          <button
            class="btn btn-secondary dropdown-toggle"
            @click="filter({filterKey})"
            type="button"
            id="reviewRatingDropdownMenu"
            data-bs-toggle="dropdown"
            aria-expanded="false"
          >
            Rating
          </button>
          <ul class="dropdown-menu" aria-labelledby="reviewRatingDropdownMenu">
            <li>
              <a href="#" v-on:click="filterKey = 'all'" :class="'dropdown-item ' + { active: userFilterKey == 'all' }">4+</a>
            </li>
            <li><a class="dropdown-item" href="#">3+</a></li>
            <li><a class="dropdown-item" href="#">2+</a></li>
            <li><a class="dropdown-item" href="#">All</a></li>
          </ul>
        </div>
      </div>
      <div class="col-md-8">
        <!-- <div class="dropdown text-end">
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
        </div> -->
      </div>
    </div>
    <div class="row">
      <Review v-for="review in allreviews" :review="review" :key="review.id" />
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
import Review from "./ReviewComponents/Review.vue";
export default {
  components: {
    Review,
  },
  mounted() {
    // console.log(this.$route.params.id);
    this.getReviews(this.$route.params.id);
  },
  data() {
    return {
      filterKey: "all",
      allreviews: undefined,
    };
  },
  computed: {
    filteredRatings: function () {
      let filter = this.filterKey;

      if (filter === "all") {
        return this.allreviews;
      } else if (filter === "4") {
        return this.reviews.filter((review) => review.rating >= 4);
      } else {
        return this.reviews.filter((review) => review.rating <= 4);
      }
    },
  },
  methods: {
    getReviews(hotelId) {
            fetch('https://localhost:44356/api/Hotel/GetReviews/' + hotelId)
                .then(response => response.json())
                .then(result => {
                    //sort by latest date first
                    this.allreviews = result.sort((x, y) =>
                    {
                      let a = new Date(x.creationDate),
                          b = new Date(y.creationDate);
                      return b - a;
                    })
                    // console.log('all reviews ')
                    console.log(this.allreviews)
                    } )
          }
    },
    // reviews() {
    //   console.log("inside review method");
    //   return this[this.filterKey];
    // },
    // all() {
    //   console.log('inside all method')
    //   return this.reviews;
    // },
    // 4() {
    //   console.log('inside 4 method')
    //   return this.reviews.filter((review) => review.rating >= 4);
    // },
    // filter: function(filterKey){
    //   this.filterKey = filterKey
    // }
  // },
};
</script>