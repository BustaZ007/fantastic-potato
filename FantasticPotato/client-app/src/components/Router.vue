<template>
    <div class="router-content">
        <router-link class="router-link" to="/">Home</router-link>
        <router-link class="router-link" to="/library">Library</router-link>
        <router-link class="router-link" to="/authors">Authors</router-link>
    </div>
</template>
<style>
    .router-content{
        display: flex;
        justify-content: center;
        height: 50px;
        padding: 10px 0 10px 0;
        background: radial-gradient(75.49% 75.49% at 61.01% 75.77%, #376A9A 0%, #2B5276 100%);
    }
    .router-link{
        font-size: 25px;
        font-family: CustomFont;
        text-decoration: none;
        color: white;
        border-right: 1px  solid #9fcdff;
        border-left: 1px solid #9fcdff;
        border-radius: 10px;
        padding: 0 25px 0 25px;
        margin: 0 25px 0 25px;
    }
    .router-link:hover{
        color: #E5E31F;
        transition: 0.5s;
        text-decoration: underline;
    }
</style>
