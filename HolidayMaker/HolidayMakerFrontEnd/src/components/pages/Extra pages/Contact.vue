<template>
<Card id="card">
    <template #content>
        <div class="content">
            <div class="contact">
                <div class="other">
                    <div class="info">
                        <h3>More Methods </h3>
                        <h3>Email</h3>
                        <div class="svg-wrap"> <a href=""><svg >
                            </svg> Ukubhuka@gmail.com</a> </div>
                            <h3>Connect</h3>
                            <ul class="profile-userbuttons">
                                <a class="btn btn-primary" style="background-color: #3b5998;" href="#!" role="button"
                                ><i class="fab fa-facebook-f"></i></a>
                                <a class="btn btn-primary" style="background-color: #55acee;" href="#!" role="button"
                                ><i class="fab fa-twitter"></i></a>
                                <a class="btn btn-primary" style="background-color: #dd4b39;" href="#!" role="button"
                                ><i class="fab fa-google"></i></a>
                                <a class="btn btn-primary" style="background-color: #ac2bac;" href="#!" role="button"
                                ><i class="fab fa-instagram"></i></a>
                            </ul>
                    </div>
                </div>
                <div class="form">
                    <h1>Contact us!</h1>
                    <form action="">
                        <div class="flex-rev"><input type="text" class="form-control" placeholder="Input name..." name="name" id="name" ><label for="name">Full name</label></div>
                        <div class="flex-rev"><input type="email" class="form-control" placeholder="Input Email..." name="email" id="email" ><label for="email"> Your Email</label></div>
                        <div class="flex-rev"> <textarea placeholder="Plez hire meh....." name="message" id="message"></textarea> <label for="message">Email Message</label> </div> <button id="buttonz">Send Email</button>
                    </form>
                </div>
            </div>
        </div>
    </template>
</Card>
</template>


<script>
import Card from 'primevue/card';

export default {
  components: {
      Card
  },
  
  
};

</script>

<style scoped>

#card{
    border-radius: 20px;
    margin-top: 30px;
}

#buttonz{
    background:#53c16e;
    border:#4e936a;
}

a,
button {
    display: inline-block;
    padding: 14px 30px;
    text-decoration: none;
    color: #243342;
    letter-spacing: 1.2px;
    font-size: 14px;
    border: 1px solid #243342;
    border-radius: 7px;
    margin-right: 20px;
    transition: 0.15s ease-in-out
}

a.focus,
button {
    color: white;
    background: #243342
}

a.focus:hover,
button:hover {
    cursor: pointer;
    color: #1bf1dc
}

a:hover {
    background-color: #243342;
    color: #16f1d7
}


.content {
    top: 60px;
    width: 100vw;
    align-items: center;
    justify-content: center;
    overflow: auto;
    padding: 20px
}

.contact {
    width: 80%;
    max-width: 1080px;
    display: flex;
    border-radius: 5px;
    overflow: hidden
}

.other {
    width: 60%;
    background-image: url(https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2Fthesocialissue.com%2Fwp-content%2Fuploads%2F2014%2F10%2FTransforming-lives1-1024x768.jpg&f=1&nofb=1);
    background-size: cover;
    background-position: center;
    position: relative;
    display: flex;
    flex-direction: column;
    justify-content: flex-end
}

.other:before {
    content: "";
    position: absolute;
    top: 0;
    left: 0;
    height: 100%;
    width: 100%;
    background: linear-gradient(45deg, rgb(36, 51, 66), rgba(36, 51, 66, 0.81))
}

.form {
    width: 39%;
    background-color: white;
    padding: 20px;
    display: flex;
    flex-direction: column;
    align-items: flex-end
}

.form h1 {
    text-align: center;
    margin-bottom: 20px;
    width: 100%
}

.form form {
    width: 100%;
    display: flex;
    flex-direction: column;
    align-items: flex-end
}

.flex-rev {
    display: flex;
    flex-direction: column-reverse;
    margin-bottom: 10px;
    width: 100%
}

.flex-rev input,
.flex-rev textarea {
    border: none;
    background-color: #e6e6e6;
    padding: 12px 10px;
    font-size: 16px;
    resize: none;
    margin-top: 7px;
    margin-bottom: 16px;
    border-radius: 5px;
    color: #243342;
    outline-color: #243342;
    outline-width: thin;
    -webkit-appearance: none
}

.flex-rev textarea {
    height: 150px
}

button {
    -webkit-appearance: none;
    margin-right: 0
}

.info {
    position: relative;
    padding: 20px
}

h2 {}

.info h2 {
    color: #16f1dc;
    font-size: 34px
}

.info h3 {
    color: white;
    letter-spacing: 1.2px;
    margin-top: 20px
}

.svg-wrap {
    margin-top: 14px
}

.svg-wrap a {
    border: 0;
    padding: 0;
    display: flex;
    color: #bbbbbb;
    font-size: 16px;
    justify-content: center;
    align-items: center;
    font-style: italic
}

.svg-wrap a svg {
    width: 20px;
    height: 20px;
    fill: white;
    transition: fill 0.2s ease-in-out;
    margin-right: 13px
}

.svg-wrap a:hover svg {
    fill: #16f1dc;
    cursor: pointer
}

.svg-wrap a:hover {
    background-color: transparent;
    color: #16f1dc;
    cursor: pointer
}

@media screen and (max-width: 900px) {
    .content {
        padding: 10px 0 0;
        display: block
    }

    .contact {
        width: 100%;
        flex-direction: column-reverse;
        border-radius: 0;
        box-shadow: 0px 0px 0px 0px
    }

    .other {
        width: 100%;
        padding: 20px 0
    }

    .form {
        width: 100%
    }
}

@media screen and (max-height: 660px) {
    .content {
        align-items: flex-start
    }
}

</style>
