<template>
  <div class="container py-5">
    <div class="row">
      <div class="col-lg-12 mx-auto">
        <h1 id="popa">Popular Hotels</h1>
        <div class="row py-5">
          <div class="col-lg-4 clickable" @click="searchHotel(hotels[0].title)">
            <figure
              class="caption-2 mb-0 shadow-sm border border-white border-md"
            >
              <img
                src="https://media-cdn.tripadvisor.com/media/photo-s/13/65/a1/96/exterior-view.jpg"
                alt=""
                class="w-100"
              />
              <figcaption class="p-4 bg-white">
                <h2 class="h5 font-weight-bold mb-2 font-italic">
                  {{hotels[0].title}}, {{hotels[0].city}}
                </h2>
                <p class="mb-0 text-small font-italic text-muted">
                  The 4-star Clayton Crown Hotel London enjoys a great location
                  with good links to Luton Airport, Wembley Stadium and Brent
                  Cross Shopping Center. Kilburn Underground Station is just a
                  short walk away, and you can reach London's West End in 30
                  minutes by public transport.
                </p>
              </figcaption>
            </figure>
          </div>

          <div class="col-lg-4 clickable" @click="searchHotel(hotels[1].title)">
            <figure
              class="caption-2 mb-0 shadow-sm border border-white border-md"
            >
              <img
                src="https://bilder.apollo.se/three-dolphins-1557016426-110210-ImageGalleryLightbox.jpg"
                alt=""
                class="w-100"
              />
              <figcaption class="p-4 bg-white">
                <h2 class="h5 font-weight-bold mb-2 font-italic">
                  {{hotels[1].title}}, {{hotels[1].city}}
                </h2>
                <p class="mb-0 text-small font-italic text-muted">
                  Family hotel in the heart of Lefkos. Only 100 meter from the
                  best beach on Karpathos
                </p>
              </figcaption>
            </figure>
          </div>

          <div class="col-lg-4 clickable" @click="searchHotel(hotels[2].title)">
            <figure
              class="caption-2 mb-0 shadow-sm border border-white border-md"
            >
              <img
                src="https://cdn.filestackcontent.com/eqoQs9XTTeCQjhJLjfPb"
                alt=""
                class="w-100"
              />
              <figcaption class="p-4 bg-white">
                <h2 class="h5 font-weight-bold mb-2 font-italic">
                  {{hotels[2].title}}, {{hotels[2].city}}
                </h2>
                <p class="mb-0 text-small font-italic text-muted">
                  This accommodation is located on the island of Bjärehalf, just
                  100 meters from the beach at Laholmsbukten. It offers free
                  WiFi and modern apartments with kitchen facilities, a
                  flat-screen TV and a private terrace or balcony.
                </p>
              </figcaption>
            </figure>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  data(){
    return{
      hotels:[
        {
          title: 'Crown Morahn Hotel',
          city: 'London',
        },
        {
          title: 'Three Dolphins',
          city: 'Lefkos',
        },
        {
          title: 'Hotel Riviera Strand',
          city: 'Båstad',
        },
      ]
    }
  },
  methods:{
    searchHotel(hotel){
        //console.log("search hotel");
        this.$store.dispatch('searchSpecific', {type: null, searchString: hotel});
      }
  }
}
</script>


<style scoped>

.clickable{
   cursor: pointer;

}

#popa{
  font-family:'Times New Roman', Times, serif;
  font-weight: bold;
  text-decoration:underline;
  color:#2c3e50;
}

</style>
