<script>
    import { page } from '$app/stores';
    let queryParam;

    $: queryParam = $page.url.searchParams.get('id');
    const removeTodo = async () => {
        var response = await fetch("https://localhost:7242/v1/assignment/" + $page.url.searchParams.get('id'), {
            method: "DELETE"
        });
        return result;
    }

    let removeTodoPromise = removeTodo();

</script>

{#await removeTodoPromise then data}
    <h1>{data}</h1>
{/await}
<a href="/">back</a>