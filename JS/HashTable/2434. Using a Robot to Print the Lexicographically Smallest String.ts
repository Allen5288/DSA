function robotWithString(s: string): string {
    let cnt: number[] = new Array(26).fill(0);
    for (let c of s) {
        cnt[c.charCodeAt(0) - "a".charCodeAt(0)]++;
    }

    let stack: string[] = [];
    let res: string[] = [];
    let minCharacter: string = "a";
    for (let c of s) {
        stack.push(c);
        cnt[c.charCodeAt(0) - "a".charCodeAt(0)]--;
        while (
            minCharacter !== "z" &&
            cnt[minCharacter.charCodeAt(0) - "a".charCodeAt(0)] === 0
        ) {
            minCharacter = String.fromCharCode(minCharacter.charCodeAt(0) + 1);
        }
        while (stack.length > 0 && stack[stack.length - 1] <= minCharacter) {
            res.push(stack.pop()!);
        }
    }

    return res.join("");
}