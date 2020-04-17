<template>
    <div>
        <Form v-model = "form">
            <TextField v-model = "form.login" value="login" label-placeholder="Login or email"></TextField>
            <TextField v-model = "form.password" value="password" label-placeholder="Password"></TextField>
            <button @click="authorization">Login</button>
        </Form>
    </div>
</template>

<script>
    import TextField from "../components/TextField";
    import Form from "../components/Form";

    export default {
        name: 'Login',
        data(){ return{
            form: {
                login: "",
                password: ""
            }
        }
        },
        components: {
            TextField,
            Form
        },
        methods: {
            authorization(){
                this.$api.post("Authorization", this.form).then(res =>
                alert(res.data));
            }
        }
    }
</script>
