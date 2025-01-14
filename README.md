# KanikamaGI

KanikamaGIはVRChatでの使用を想定した、ライトマップをランタイムで更新する仕組みです。

[![Kanikama1](https://i.gyazo.com/5bbd65b932e19e91408ce1673651c52c.gif)](https://gyazo.com/5bbd65b932e19e91408ce1673651c52c) [![Image from Gyazo](https://i.gyazo.com/56f1b1a12ef98c8d50b79b992e2e1985.gif)](https://gyazo.com/56f1b1a12ef98c8d50b79b992e2e1985)

動作環境
- Unity2019.4.29f1
- VRChat SDK3
- [MerlinVR/UdonSharp](https://github.com/MerlinVR/UdonSharp)

使い方

- [kanikama/wiki](https://github.com/shivaduke28/kanikama/wiki)

動作確認用ワールド
- [KanikamaGI Test World](https://vrchat.com/home/launch?worldId=wrld_ebb1341f-15b5-4ca6-9f38-575dfb01bf01)


---

特徴

- Udonを使っているのでVRChatで動きます。
- UnityのRealtimeGIを使用しないため、高負荷でも（多分）止まりません。
- 毎フレーム更新できます。
- 通常の静的なGIと併用できます。
- StanardシェーダーにKanikama機能を追加したシェーダーが入っています。
- Directionalモードに対応しています。

残念なところ

- 光源の数だけライトマップの枚数が増えるため、ワールドの容量が大きくなります。
- ライトプローブの動的な更新はできません。
- Bakery未対応（いつか対応します）


光源として使えるもの

- ライト
  - Baked、Mixedに対応しています。
- 発光マテリアル
  - StandardシェーダーのEmissionに対応しています。
- 環境光
  - Ambient Lightの明るさと色を変えることができます。
- モニター
  - 画面を最大で16個のマスに分割して、それぞれを発光マテリアルをつけた板ポリとして扱うことでGIに映像を反映します。


仕組み

1. 事前に光源の数だけライトマップをベイクします。
2. ランタイムではUdonとシェーダーを使って、ベイクした複数のライトマップを合成し、RenderTextureに出力します。
3. RenderTextureは事前にGIを反映されたいオブジェクトのマテリアルに配っておくので、ライティングが更新されます。



仕組み自体はよく知られており、新しいものではありません。KanikamaGIの開発では以下を参考にしました。

- [無　解説 - Imaginantia](https://phi16.hatenablog.com/entry/2021/05/29/204643)
- [ProjectCiAN 制作記｜wata_pj｜note](https://note.com/wata_pj/n/n612f66466313)
- リアルタイムレンダリング 第4版 11章


また、開発では以下のリポジトリとアセットにお世話になりました。
- [esnya/UdonRabbit.Analyze](https://github.com/esnya/UdonRabbit.Analyzer)
- [CyanLaser/CyanEmu](https://github.com/CyanLaser/CyanEmu)
- [TopazChat Player 3.0 - よしたかのBOOTH](https://booth.pm/ja/items/1752066)

---

LICENSE

MIT

---

Links

- [KanikamaGI Discord](https://discord.gg/ze7dq8nGhW)
- [https://twitter.com/shiva_duke28 (my twitter)](https://twitter.com/shiva_duke28)
- pull requests will be very wellcomed <3
