<template>
  <div>
    <div class="row pt-5">
      <div class="col-md-10">
        <h2>Guest reviews</h2>
      </div>
      <div class="col-md-2 text-end">
        <router-link :to="'/hotels/' + this.$route.params.id + '/AddReview'">
          <button type="button" class="btn btn-primary">Add review</button>
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
              <a v-on:click="ratingFilterKey = 'all'" :class="'dropdown-item ' + { active: ratingFilterKey == 'all' }">All</a>
            </li>
            <li>
              <a  v-on:click="ratingFilterKey = 'only4'" :class="'dropdown-item ' + { active: ratingFilterKey == 'only4' }">4+</a>
            </li>
            <li>
              <a v-on:click="ratingFilterKey = 'only3'" :class="'dropdown-item ' + { active: ratingFilterKey == 'only3' }">3+</a>
            </li>
            <li>
              <a v-on:click="ratingFilterKey = 'below3'" :class="'dropdown-item ' + { active: ratingFilterKey == 'below3' }">Below 3</a>
            </li>
          </ul>
        </div>
      </div>
    </div>
    <div class="row">
      <Review v-for="review in ratingFilterList" :review="review" :key="review.id" />
    </div>
    <!-- <div class="row">
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
    </div> -->
  </div>
</template>

<style scoped>

  h2 {
    margin-left: 5cm;
  }

  .dropdown{
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
    // console.log(this.$route.params.id);
    this.getReviews(this.$route.params.id);
  },
  data() {
    return {
      ratingFilterKey: "all",
      allreviews: undefined,
    };
  },
  computed: {
    ratingFilterList() {
    	return this[this.ratingFilterKey]
    },
    all(){
      return this.allreviews
    },
    only4(){
      return this.allreviews.filter((user) => user.rating >= 4)
    },
    only3(){
      return this.allreviews.filter((user) => user.rating >= 3)
    },
    below3(){
      return this.allreviews.filter((user) => user.rating <3)
    }
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
                    // console.log(this.allreviews)
                    } )
          }
    },
};
</script>