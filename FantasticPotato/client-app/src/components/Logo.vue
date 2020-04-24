<template>
    <div class="logo-content">
        <img  class="logo-img" src="../img/book.png">
        <span class="logo-span">BookFinder</span>
        <slot class="logo-slot"></slot>
    </div>
</template>
<style>
    @font-face {
        font-family: "CustomFont";
        src: url("../fonts/10369.ttf");
    }
    .logo-content{
        height: 70px;
        background: radial-gradient(75.49% 75.49% at 61.01% 75.77%, #376A9A 0%, #2B5276 100%);
        padding-top: 30px;
        padding-left: 50px;
        padding-right: 50px;
    }
    .logo-img{
        height: 40px;
        float: left;
        background: none;
        -webkit-filter: invert(1);
        filter: invert(1);
    }
    .logo-slot{
        float: right;
    }
    .logo-span{
        margin-left: 20px;
        color: white;
        font-family: CustomFont;
        font-size: 25px;
    }

</style>
