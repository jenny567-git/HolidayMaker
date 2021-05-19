<template>
  <div class="py-5">
    <h3 class="font-weight-bold mb-0">Popular Destinations</h3>

    <div class="row">
      <!-- DEMO 2 Item-->
      <div class="col-lg-6 mb-3 mb-lg-0">
        <div class="hover hover-2 text-white rounded">
          <img
            src="https://bilder.apollo.se/three-dolphins-1557016426-110210-ImageGalleryLightbox.jpg"
            alt=""
          />
          <div class="hover-overlay"></div>
          <div class="hover-2-content px-5 py-4">
            <p class="hover-2-description text-uppercase mb-0">
              Lefkos <br />See available hotels in Lefkos, Karpathos
            </p>
          </div>
        </div>
      </div>
    </div>

    <div class="row">
      <!-- DEMO 2 Item-->
      <div class="col-lg-6 mb-3 mb-lg-0">
        <div class="hover hover-2 text-white rounded">
          <img
            src="https://blog.fly.deals/wp-content/uploads/2020/06/London_Tower_Bridge_City.jpg"
            alt=""
            class="thumbnail"
          />
          <div class="hover-overlay"></div>
          <div class="hover-2-content px-5 py-4">
            <p class="hover-2-description text-uppercase mb-0">
              London <br />See available hotels in London
            </p>
          </div>
        </div>
      </div>
    </div>

    <div class="row">
      <!-- DEMO 2 Item-->
      <div class="col-lg-6 mb-3 mb-lg-0">
        <div class="hover hover-2 text-white rounded">
          <img
            src="https://media.radissonhotels.net/image/destination-pages/localattraction/16256-118729-f63244989_3xl.jpg?impolicy=HomeHero"
            alt=""
          />
          <div class="hover-overlay"></div>
          <div class="hover-2-content px-5 py-4">
            <p class="hover-2-description text-uppercase mb-0">
              Berlin <br />See available hotels in Berlin
            </p>
          </div>
        </div>
      </div>
    </div>

    <div class="row">
      <!-- DEMO 2 Item-->
      <div class="col-lg-6 mb-3 mb-lg-0">
        <div class="hover hover-2 text-white rounded">
          <img
            src="https://www.flytap.com/-/media/Flytap/new-tap-pages/destinations/europe/denmark/copenhagen/destinations-copenhagen-banner-mobile-1024x553.jpg"
            alt=""
          />
          <div class="hover-overlay"></div>
          <div class="hover-2-content px-5 py-4">
            <p class="hover-2-description text-uppercase mb-0">
              Copenhangen <br />See available hotels in Copenhange
            </p>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style>
.hover {
  overflow: hidden;
  position: relative;
  padding-bottom: 40%;
}

.hover-overlay {
  width: 75%;
  height: 100%;
  position: absolute;
  top: 0;
  left: 0;
  z-index: 90;
  transition: all 0.4s;
}

.hover img {
  width: 75%;
  position: absolute;
  top: 0;
  left: 0;
  transition: all 0.3s;
}

.hover-content {
  position: relative;
  z-index: 99;
}

.hover-2 .hover-overlay {
  background: linear-gradient(to top, rgba(0, 0, 0, 0.4), rgba(0, 0, 0, 0.1));
}

.hover-2-title {
  position: absolute;
  top: 50%;
  left: 0;
  text-align: center;
  width: 100%;
  z-index: 99;
  transition: all 0.3s;
}

.hover-2-description {
  width: 75%;
  position: absolute;
  bottom: 0;
  opacity: 0;
  left: 0;
  text-align: center;
  z-index: 99;
  transition: all 0.3s;
}

.hover-2:hover .hover-2-title {
  transform: translateY(-1.5rem);
}

.hover-2:hover .hover-2-description {
  bottom: 0.5rem;
  opacity: 1;
}

.hover-2:hover .hover-overlay {
  background: linear-gradient(to top, rgba(0, 0, 0, 0.9), rgba(0, 0, 0, 0.1));
}
</style>
