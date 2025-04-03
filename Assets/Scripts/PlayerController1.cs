//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class PlayerController1 : MonoBehaviour
//{
//    public GameEvent FamilyNearby;
//    public FamilyData familyNearbyData;

//    //To manage inventories added as objects in inspector
//    private InventoryManager inventoryManager;

//    private Rigidbody2D rb;
//    public Vector2 movement;
//    public int speed = 10;

//    // Dictionary to track active listeners keyed by the collided GameObject.
//    private Dictionary<GameObject, GameEventListener> activeFamilyListeners = new Dictionary<GameObject, GameEventListener>();

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        if (GetComponentInChildren<InventoryManager>() != null)
//        {
//            inventoryManager = GetComponentInChildren<InventoryManager>();
//        }
//    }

//    public void OnMove(InputValue value)
//    {
//        movement = value.Get<Vector2>();
//    }

//    private void FixedUpdate()
//    {
//        rb.linearVelocity = movement * speed;
//    }

//    /// <summary>
//    /// When nearby a FamilyNearbyListener suscribe the objects listener to FamilyNearby GameEvent.
//    /// DialogueMessenger.Send() can be called to events to send DialogueManager all suscribers,
//    /// DialogueManager must decide if a priority to act is needed
//    /// </summary>
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        //If is a memory, destroy Gameobject (memory collection is managed in the collectible object)
//        if(collision.CompareTag("Memory"))
//        {
//            Destroy(collision.gameObject);
        
//            if (inventoryManager.memoriesInventory != null)
//            {
//                inventoryManager.memoriesInventory.Add(collision.gameObject.GetComponent<CollectibleObject>());
//            }
//        }

//        //If not memory, check if has familyData and subscribe its listener to familyNearbyListener
//        else
//        {
//            Debug.Log("Tag is not Memory");
//            if (inventoryManager.familyInventory != null)
//            {
//                Debug.Log("Family Inventory not null in inventory manager");
//                Debug.Log("CollectibleObject found " + collision.gameObject.GetComponentInChildren<CollectibleObject>().name);
//                inventoryManager.familyInventory.Add(collision.gameObject.GetComponentInChildren<CollectibleObject>());
//                Debug.Log("family"+ collision.gameObject.GetComponentInChildren<CollectibleObject>().name + "added to " +inventoryManager.familyInventory.gameObject.name);  
//            }

//            // First, check and store the FamilyData (if a Family component exists)
//            FindFamilyData(collision.gameObject);

//            // Then, attempt to find the "FamilyNearbyListener" child.
//            GameEventListener familyNearbyListener = FindFamilyNearbyListener(collision.gameObject);

//            // Use the helper method to subscribe the listener if possible.
//            if (!SubscribeFamilyListener(collision.gameObject, familyNearbyListener))
//            {
//                return;
//            }

//            // Trigger the event so that other systems (like DialogueMessenger) can react.
//            FamilyNearby.TriggerEvent();
//        }
        
//    }

//    private void OnTriggerExit2D(Collider2D collision)
//    {
//        // Look for the GameEventListener tracked for this collision object.
//        if (activeFamilyListeners.TryGetValue(collision.gameObject, out GameEventListener listener))
//        {
//            // Disabling the listener will trigger its OnDisable() to unsubscribe from the event.
//            listener.enabled = false;
//            activeFamilyListeners.Remove(collision.gameObject);

//            Debug.Log("Player exited collision with 'NearbyListener' on: " + collision.gameObject.name);
//        }
//    }

//    /// <summary>
//    /// Checks the given object for a child GameEventListener with the name "FamilyNearbyListener".
//    /// Returns the listener if found; otherwise, logs a warning and returns null.
//    /// </summary>
//    private GameEventListener FindFamilyNearbyListener(GameObject obj)
//    {
//        GameEventListener familyNearbyListener = obj.GetComponentsInChildren<GameEventListener>()
//            .FirstOrDefault(listener => listener.gameObject.name == "FamilyNearbyListener");

//        if (familyNearbyListener == null)
//        {
//            //Debug.LogWarning("No GameEventListener named 'FamilyNearbyListener' found on object: " + obj.name);
//        }

//        return familyNearbyListener;
//    }

//    /// <summary>
//    /// Checks whether the given object contains a Family component.
//    /// If found, stores its FamilyData into familyNearbyData.
//    /// </summary>
//    private void FindFamilyData(GameObject obj)
//    {
//        if (obj.TryGetComponent<Family>(out Family family))
//        {
//            familyNearbyData = family.data;
//            Debug.Log("Family data stored: " + family.data.collectibleName);
//        }
//        else
//        {
//            //Debug.LogWarning("No Family component found on object: " + obj.name);
//        }
//    }

//    /// <summary>
//    /// If the targetListener is not null and the collision object is not already registered,
//    /// subscribes the listener by adding it to the dictionary and enabling it.
//    /// Returns true if subscription is successful.
//    /// </summary>
//    private bool SubscribeFamilyListener(GameObject collisionObject, GameEventListener familyNearbyListener)
//    {
//        if (familyNearbyListener == null)
//        {
//            // Target listener not found—exit early.
//            return false;
//        }

//        // Check for duplicate subscription.
//        if (!activeFamilyListeners.ContainsKey(collisionObject))
//        {
//            activeFamilyListeners.Add(collisionObject, familyNearbyListener);

//            // Enable the listener so that its OnEnable() subscribes it to FamilyNearby.
//            familyNearbyListener.enabled = true;

//            Debug.Log("Player entered collision with 'FamilyNearbyListener' on: " + collisionObject.name);
//            return true;
//        }
//        return false;
//    }

    
//}
