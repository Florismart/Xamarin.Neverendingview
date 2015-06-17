Neverendingview
===============


Neverendingview is an Open Source Android library that allows developers to easily add a neverending scroll view to their projects. Feel free to use it all you want in your Android apps provided that you cite this project and include the license in your app.


![Screenshot](https://raw2.github.com/Florismart/Neverendingview/master/screen-app.png)


Setup
-----
__1.__ In Xamarin, import the library as an Android library project. Project > Clean to generate the binaries 
you need.

__2.__ Then, add Neverendingview as a dependency to your existing project.

Or just include via nuget ass Florismart.Neverendingview.Droid


XML Usage
-----
All options are optional. Use only those you really want to customize.

Horizontal
-----

```xml
<Florismart.Neverendingview.Droid.Views.HorizontalNeverendingView>
        xmlns:neverending="http://schemas.android.com/apk/res-auto"
        android:id="@+id/my_neverendingview1"
        style="@style/Neverendingview.Horizontal"
        neverending:enabled="true"
        neverending:mode="natural"
        neverending:speed="falcon"
        neverending:frequency="10"
        neverending:delta="2">
        <LinearLayout
            style="@style/NeverendingContainer.Horizontal"
            android:orientation="horizontal">
            <TextView
                android:layout_width="wrap_content"
                android:layout_height="match_parent"
                android:text="@string/quote_one" />
        </LinearLayout>
    </Florismart.Neverendingview.Droid.Views.HorizontalNeverendingView>
```

Vertical
-----

```xml
<Florismart.Neverendingview.Droid.Views.VerticalNeverendingView>
    xmlns:neverending="http://schemas.android.com/apk/res-auto"
    android:id="@+id/my_neverendingview2"
    style="@style/Neverendingview.Vertical"
        neverending:enabled="true"
        neverending:mode="natural"
        neverending:speed="falcon"
        neverending:frequency="10"
        neverending:delta="2">
    <LinearLayout
        style="@style/NeverendingContainer.Vertical"
        android:orientation="vertical" >

        <TextView
            style="@style/Content.TextView"
            android:text="@string/quote_two" />
            
    </LinearLayout>
        
</Florismart.Neverendingview.Droid.Views.VerticalNeverendingView
```


